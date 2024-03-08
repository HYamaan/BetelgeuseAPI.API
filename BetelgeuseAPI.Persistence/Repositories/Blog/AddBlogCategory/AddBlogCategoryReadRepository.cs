using BetelgeuseAPI.Application.Repositories.Blog.AddBlogCategory;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Blog.AddBlogCategory;

public class AddBlogCategoryReadRepository : ReadRepository<IdentityContext, BlogCategories>, IAddBlogCategoryReadRepository
{
    public AddBlogCategoryReadRepository(IdentityContext context) : base(context)
    {
    }
}