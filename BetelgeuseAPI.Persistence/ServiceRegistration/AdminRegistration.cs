using BetelgeuseAPI.Application.Repositories.Admin.AddBlogCategory;
using BetelgeuseAPI.Application.Repositories.UserAccountSkill;
using BetelgeuseAPI.Persistence.Repositories.Admin.Blog.AddBlogCategory;
using BetelgeuseAPI.Persistence.Repositories.UserAccountSkill;
using Microsoft.Extensions.DependencyInjection;

namespace BetelgeuseAPI.Persistence;

public static class AdminRegistration
{
    public static void AddAdminServices(this IServiceCollection services)
    {
        services.AddScoped<IAllUserAccountSkillWriteRepository, AllUserAccountSkillWriteRepository>();
        services.AddScoped<IAllUserAccountSkillReadRepository, AllUserAccountSkillReadRepository>();
        services.AddScoped<IAddBlogCategoryReadRepository, AddBlogCategoryReadRepository>();
        services.AddScoped<IAddBlogCategoryWriteRepository, AddBlogCategoryWriteRepository>();
    }
}