using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Repositories;
using BetelgeuseAPI.Application.Repositories.User;
using BetelgeuseAPI.Application.Repositories.UserAccountEducation;
using BetelgeuseAPI.Application.Repositories.UserAccountExperiences;
using BetelgeuseAPI.Application.Repositories.UserAccountInformation;
using BetelgeuseAPI.Application.Repositories.UserAccountInformationAbout;
using BetelgeuseAPI.Application.Repositories.UserProfileImageFile;
using BetelgeuseAPI.Application.Repositories.UserRefreshToken;
using BetelgeuseAPI.Application.Repositories.VideoUploadFile;
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Persistence.Context;
using BetelgeuseAPI.Persistence.Extension;
using BetelgeuseAPI.Persistence.Repositories;
using BetelgeuseAPI.Persistence.Repositories.File;
using BetelgeuseAPI.Persistence.Repositories.User;
using BetelgeuseAPI.Persistence.Repositories.UserAccountInformation;
using BetelgeuseAPI.Persistence.Repositories.UserAccountInformationAbout;
using BetelgeuseAPI.Persistence.Repositories.UserProfileImageFile;
using BetelgeuseAPI.Persistence.Repositories.UserRefreshToken;
using BetelgeuseAPI.Persistence.Repositories.VideoUploadFile;
using BetelgeuseAPI.Persistence.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace BetelgeuseAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<BetelgeuseAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddDbContext<IdentityContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 3;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@.-_+";

            }).AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();
            services.AddSwaggerOpenAPI();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepository>();
            services.AddScoped<IUserProfileImageFileWriteRepository, UserProfileImageFileWriteRepository>();
            services.AddScoped<IUserProfileImageFileReadRepository, UserProfileImageFileReadRepository>();
            services.AddScoped<IVideoUploadFileWriteRepository, VideoUploadFileWriteRepository>();
            services.AddScoped<IVideoUploadFileReadRepository, VideoUploadFileReadRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IUserRefreshTokenReadRepository, UserRefreshTokenReadRepository>();
            services.AddScoped<IUserRefreshTokenWriteRepository, UserRefreshTokenWriteRepository>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IUserAccountInformationWriteRepository, UserAccountInformationWriteRepository>();
            services.AddScoped<IUserAccountInformationReadRepository, UserAccountInformationReadRepository>();
            services.AddScoped<IUserAccountAboutReadRepository, UserAccountAboutReadRepository>();
            services.AddScoped<IUserAccountAboutWriteRepository, UserAccountAboutWriteRepository>();
            services.AddScoped<IUserAccountEducationReadRepository, UserAccountEducationReadRepository>();
            services.AddScoped<IUserAccountEducationWriteRepository, UserAccountEducationWriteRepository>();
            services.AddScoped<IUserAccountExperiencesReadRepository, UserAccountExperiencesReadRepository>();
            services.AddScoped<IUserAccountExperiencesWriteRepository, UserAccountExperiencesWriteRepository>();
        }
    }
}