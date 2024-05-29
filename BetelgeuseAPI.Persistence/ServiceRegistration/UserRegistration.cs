using BetelgeuseAPI.Application.Repositories.FileContent.UserProfileBackgroundImageFile;
using BetelgeuseAPI.Application.Repositories.FileContent.UserProfileImageFile;
using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountAbout;
using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountEducation;
using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountExperiences;
using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountInformation;
using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountSkills;
using BetelgeuseAPI.Application.Repositories.UserQuizInteraction;
using BetelgeuseAPI.Application.Repositories.UserRefreshToken;
using BetelgeuseAPI.Persistence.Repositories.FileContent.UserProfileBackgroundImageFile;
using BetelgeuseAPI.Persistence.Repositories.FileContent.UserProfileImageFile;
using BetelgeuseAPI.Persistence.Repositories.UserQuizInteraction;
using BetelgeuseAPI.Persistence.Repositories.UserRefreshToken;
using BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountEducation;
using BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountExperiences;
using BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountInformation;
using BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountInformationAbout;
using BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountSkills;
using Microsoft.Extensions.DependencyInjection;

namespace BetelgeuseAPI.Persistence;

public static class UserRegistration
{
    public static void AddUserServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRefreshTokenReadRepository, UserRefreshTokenReadRepository>();
        services.AddScoped<IUserRefreshTokenWriteRepository, UserRefreshTokenWriteRepository>();
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

        services.AddScoped<IUserQuizInteractionReadRepository, UserQuizInteractionReadRepository>();
        services.AddScoped<IUserQuizInteractionWriteRepository, UserQuizInteractionWriteRepository>();
    }
}