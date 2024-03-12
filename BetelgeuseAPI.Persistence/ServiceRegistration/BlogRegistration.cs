﻿using BetelgeuseAPI.Application.Repositories.Blog.BlogImage;
using BetelgeuseAPI.Application.Repositories.Blog.CreateBlog;
using BetelgeuseAPI.Persistence.Repositories.Blog.BlogImage;
using BetelgeuseAPI.Persistence.Repositories.Blog.CreateBlog;
using Microsoft.Extensions.DependencyInjection;

namespace BetelgeuseAPI.Persistence;

public static class BlogRegistration
{
    public static void AddBlogServices(this IServiceCollection services)
    {
        services.AddScoped<IBlogImageReadRepository,BlogImageReadRepository>();
        services.AddScoped<IBlogImageWriteRepository,BlogImageWriteRepository>();
        services.AddScoped<IBlogReadRepository, BlogReadRepository>();
        services.AddScoped<IBlogWriteRepository, BlogWriteRepository>();
    }
}