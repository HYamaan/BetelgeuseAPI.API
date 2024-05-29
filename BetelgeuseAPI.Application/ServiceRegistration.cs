
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text;
using BetelgeuseAPI.Domain.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using BetelgeuseAPI.Domain.Common;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace BetelgeuseAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.Configure<GoogleAuthSettings>(configuration.GetSection("GoogleAuthSettings"));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JWTSettings:Issuer"],
                    ValidAudience = configuration["JWTSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:SecurityKey"]))
                };
                o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.NoResult();
                        c.Response.StatusCode = 500;
                        c.Response.ContentType = "text/plain";
                        var result = JsonConvert.SerializeObject(Response<string>.Fail($"{c.Exception}"));
                        return c.Response.WriteAsync(result);
                    },
                    OnChallenge = context =>
                    {
                        if (!context.Response.HasStarted)
                        {
                            context.HandleResponse();
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject(Response<string>.Fail("You are not Authorized"));
                            return context.Response.WriteAsync(result);
                        }
                        return Task.CompletedTask;
                    },
                    OnForbidden = context =>
                    {
                        if (!context.Response.HasStarted)
                        {
                            context.Response.StatusCode = 403;
                            context.Response.ContentType = "application/json";
                            var result =
                                JsonConvert.SerializeObject(
                                    Response<string>.Fail("You are not authorized to access this resource"));
                            return context.Response.WriteAsync(result);
                        }
                        return Task.CompletedTask;
                    },
                };
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddHangfire(x => x.UsePostgreSqlStorage(configuration.GetConnectionString("PostgreSQL")));
            services.AddHangfireServer(x =>
            {
                x.WorkerCount = 500;
            });

        }
    }
}