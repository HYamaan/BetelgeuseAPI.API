using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Repositories.Category;
using BetelgeuseAPI.Application.Repositories.Category.BlogCategory;
using BetelgeuseAPI.Application.Repositories.Category.CourseCategory;
using BetelgeuseAPI.Application.Repositories.Category.EBookCategory;
using BetelgeuseAPI.Persistence.Repositories.Category;
using BetelgeuseAPI.Persistence.Repositories.Category.BlogCategory;
using BetelgeuseAPI.Persistence.Repositories.Category.CourseCategory;
using BetelgeuseAPI.Persistence.Repositories.Category.EBookCategory;
using BetelgeuseAPI.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BetelgeuseAPI.Persistence;

public static class CategoryRegistration
{
    public static void AddCategoryService(this IServiceCollection services)
    {
        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IBlogCategoryReadRepository, BlogCategoryReadRepository>();
        services.AddScoped<IBlogCategoryWriteRepository, BlogCategoryWriteRepository>();
        services.AddScoped<ICourseCategoryReadRepository, CourseCategoryReadRepository>();
        services.AddScoped<ICourseCategoryWriteRepository, CourseCategoryWriteRepository>();
        services.AddScoped<IEBookCategoryReadRepository, EBookCategoryReadRepository>();
        services.AddScoped<IEBookCategoryWriteRepository, EBookCategoryWriteRepository>();
    }
}