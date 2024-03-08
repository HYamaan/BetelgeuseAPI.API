using BetelgeuseAPI.Application.Repositories.Blog.AddBlogCategory;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Blog.AddBlogCategory;

public class AddBlogCategoryWriteRepository : WriteRepository<IdentityContext, BlogCategories>, IAddBlogCategoryWriteRepository
{
    public AddBlogCategoryWriteRepository(IdentityContext context) : base(context)
    {
    }
}