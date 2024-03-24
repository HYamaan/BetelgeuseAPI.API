using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Repositories.Category.CourseCategory;
using BetelgeuseAPI.Application.Repositories.Course.BasicInformation;
using BetelgeuseAPI.Application.Repositories.Course.CourseContent;
using BetelgeuseAPI.Application.Repositories.Course.CourseQuiz;
using BetelgeuseAPI.Application.Repositories.Course.CourseQuizAnswer;
using BetelgeuseAPI.Application.Repositories.Course.CourseSource;
using BetelgeuseAPI.Application.Repositories.Course.InclusiveCourse;
using BetelgeuseAPI.Application.Repositories.FileContent.CourseCoverImage;
using BetelgeuseAPI.Application.Repositories.FileContent.CourseQuizQuestionImage;
using BetelgeuseAPI.Application.Repositories.FileContent.CourseQuizQuestionVideo;
using BetelgeuseAPI.Application.Repositories.FileContent.CourseThumbnail;
using BetelgeuseAPI.Application.Repositories.FileContent.CourseUpload;
using BetelgeuseAPI.Persistence.Repositories.Category.CourseCategory;
using BetelgeuseAPI.Persistence.Repositories.Course.BasicInformation;
using BetelgeuseAPI.Persistence.Repositories.Course.CourseContent;
using BetelgeuseAPI.Persistence.Repositories.Course.CourseQuiz;
using BetelgeuseAPI.Persistence.Repositories.Course.CourseQuizAnswer;
using BetelgeuseAPI.Persistence.Repositories.Course.CourseSource;
using BetelgeuseAPI.Persistence.Repositories.Course.InclusiveCourse;
using BetelgeuseAPI.Persistence.Repositories.FileContent.CourseCoverImage;
using BetelgeuseAPI.Persistence.Repositories.FileContent.CourseQuizQuestionImage;
using BetelgeuseAPI.Persistence.Repositories.FileContent.CourseQuizQuestionVideo;
using BetelgeuseAPI.Persistence.Repositories.FileContent.CourseThumbnail;
using BetelgeuseAPI.Persistence.Repositories.FileContent.CourseUpload;
using BetelgeuseAPI.Persistence.Repositories.UserAccountSkill;
using BetelgeuseAPI.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BetelgeuseAPI.Persistence;

public static class CourseRegistration
{
    public static void AddCourseServices(this IServiceCollection services)
    {
        services.AddScoped<ICourseService, CourseService>();

        services.AddScoped<ICourseBasicInformationReadRepository, CourseBasicInformationReadRepository>();
        services.AddScoped<ICourseBasicInformationWriteRepository, CourseBasicInformationWriteRepository>();

        services.AddScoped<ICourseCategoryWriteRepository, CourseCategoryWriteRepository>();
        services.AddScoped<ICourseCategoryReadRepository, CourseCategoryReadRepository>();

        services.AddScoped<ICourseCoverImageReadRepository, CourseCoverImageReadRepository>();
        services.AddScoped<ICourseCoverImageWriteRepository, CourseCoverImageWriteRepository>();

        services.AddScoped<ICourseThumbnailReadRepository, CourseThumbnailReadRepository>();
        services.AddScoped<ICourseThumbnailWriteRepository, CourseThumbnailWriteRepository>();

        services.AddScoped<IInclusiveCourseReadRepository, InclusiveCourseReadRepository>();
        services.AddScoped<IInclusiveCourseWriteRepository, InclusiveCourseWriteRepository>();

        services.AddScoped<ICourseContentSectionReadRepository,CourseContentSectionReadRepository>();
        services.AddScoped<ICourseContentSectionWriteRepository,CourseContentSectionWriteRepository>();

        services.AddScoped<ICourseSourceReadRepository, CourseSourceReadRepository>();
        services.AddScoped<ICourseSourceWriteRepository, CourseSourceWriteRepository>();

        services.AddScoped<ICourseUploadReadRepository, CourseUploadReadRepository>();
        services.AddScoped<ICourseUploadWriteRepository, CourseUploadWriteRepository>();

        services.AddScoped<ICourseQuizesReadRepository, CourseQuizesReadRepository>();
        services.AddScoped<ICourseQuizesWriteRepository, CourseQuizesWriteRepository>();


        services.AddScoped<ICourseQuizQuestionVideoReadRepository, CourseQuizQuestionVideoReadRepository>();
        services.AddScoped<ICourseQuizQuestionVideoWriteRepository, CourseQuizQuestionVideoWriteRepository>();

        services.AddScoped<ICourseQuizQuestionImageReadRepository, CourseQuizQuestionImageReadRepository>();
        services.AddScoped<ICourseQuizQuestionImageWriteRepository, CourseQuizQuestionImageWriteRepository>();

        services.AddScoped<ICourseQuizAnswerReadRepository, CourseQuizAnswerReadRepository>();
        services.AddScoped<ICourseQuizAnswerWriteRepository, CourseQuizAnswerWriteRepository>();


    }
}