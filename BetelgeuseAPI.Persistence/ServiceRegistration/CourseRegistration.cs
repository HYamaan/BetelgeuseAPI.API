using BetelgeuseAPI.Application.Repositories.Category.CourseCategory;
using BetelgeuseAPI.Application.Repositories.Course.BasicInformation;
using BetelgeuseAPI.Application.Repositories.FileContent.CourseCoverImage;
using BetelgeuseAPI.Application.Repositories.FileContent.CourseThumbnail;
using BetelgeuseAPI.Application.Repositories.UserAccountSkill;
using BetelgeuseAPI.Persistence.Repositories.Category.CourseCategory;
using BetelgeuseAPI.Persistence.Repositories.Course.BasicInformation;
using BetelgeuseAPI.Persistence.Repositories.FileContent.CourseCoverImage;
using BetelgeuseAPI.Persistence.Repositories.FileContent.CourseThumbnail;
using BetelgeuseAPI.Persistence.Repositories.UserAccountSkill;
using Microsoft.Extensions.DependencyInjection;

namespace BetelgeuseAPI.Persistence;

public static class CourseRegistration
{
    public static void AddCourseServices(this IServiceCollection services)
    {
        services.AddScoped<ICourseBasicInformationReadRepository, CourseBasicInformationReadRepository>();
        services.AddScoped<ICourseCategoryWriteRepository, CourseCategoryWriteRepository>();
        services.AddScoped<ICourseCoverImageReadRepository, CourseCoverImageReadRepository>();
        services.AddScoped<ICourseCoverImageWriteRepository, CourseCoverImageWriteRepository>();
        services.AddScoped<ICourseThumbnailReadRepository, CourseThumbnailReadRepository>();
        services.AddScoped<ICourseThumbnailWriteRepository, CourseThumbnailWriteRepository>();
    }
}