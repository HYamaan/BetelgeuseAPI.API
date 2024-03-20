using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Repositories.Blog.CreateBlog;
using BetelgeuseAPI.Application.Repositories.FileContent.BlogImage;
using BetelgeuseAPI.Persistence.Repositories.Blog.BlogImage;
using BetelgeuseAPI.Persistence.Repositories.Blog.CreateBlog;
using BetelgeuseAPI.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BetelgeuseAPI.Persistence;

public static class BlogRegistration
{
    public static void AddBlogServices(this IServiceCollection services)
    {
        services.AddScoped<IBlogService, BlogService>();
        services.AddScoped<IBlogImageReadRepository,BlogImageReadRepository>();
        services.AddScoped<IBlogImageWriteRepository,BlogImageWriteRepository>();
        services.AddScoped<IBlogReadRepository, BlogReadRepository>();
        services.AddScoped<IBlogWriteRepository, BlogWriteRepository>();
    }
}