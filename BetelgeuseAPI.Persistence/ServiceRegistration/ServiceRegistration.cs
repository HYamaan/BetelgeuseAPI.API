using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Repositories;
using BetelgeuseAPI.Application.Repositories.FileContent.File;
using BetelgeuseAPI.Application.Repositories.FileContent.UserProfileBackgroundImageFile;
using BetelgeuseAPI.Application.Repositories.FileContent.UserProfileImageFile;
using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountAbout;
using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountEducation;
using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountExperiences;
using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountInformation;
using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountSkills;
using BetelgeuseAPI.Application.Repositories.UserRefreshToken;
using BetelgeuseAPI.Application.Repositories.VideoUploadFile;
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Persistence.Context;
using BetelgeuseAPI.Persistence.Extension;
using BetelgeuseAPI.Persistence.Helpers;
using BetelgeuseAPI.Persistence.Repositories;
using BetelgeuseAPI.Persistence.Repositories.FileContent.File;
using BetelgeuseAPI.Persistence.Repositories.FileContent.UserProfileBackgroundImageFile;
using BetelgeuseAPI.Persistence.Repositories.FileContent.UserProfileImageFile;
using BetelgeuseAPI.Persistence.Repositories.UserRefreshToken;
using BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountEducation;
using BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountExperiences;
using BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountInformation;
using BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountInformationAbout;
using BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountSkills;
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
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IServicesHelper, ServicesHelper>();
            services.AddScoped(typeof(IImageService<,,>), typeof(ImageService<,,>));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepository>();
            services.AddScoped<IVideoUploadFileWriteRepository, VideoUploadFileWriteRepository>();
            services.AddScoped<IVideoUploadFileReadRepository, VideoUploadFileReadRepository>();
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
            services.AddScoped<IUserProfileBackgroundImageFileReadRepository, UserProfileBackgroundImageFileReadRepository>();
            services.AddScoped<IUserProfileBackgroundImageFileWriteRepository, UserProfileBackgroundImageFileWriteRepository>();
            services.AddScoped<IUserProfileImageFileWriteRepository, UserProfileImageFileWriteRepository>();
            services.AddScoped<IUserProfileImageFileReadRepository, UserProfileImageFileReadRepository>();
            services.AddScoped<IUserAccountSkillsWriteRepository, UserAccountSkillsWriteRepository>();
            services.AddScoped<IUserAccountSkillsReadRepository, UserAccountSkillsReadRepository>();
            services.AddAdminServices();
            services.AddBlogServices();
            services.AddCategoryService();
            services.AddCourseServices();
        }
    }
}