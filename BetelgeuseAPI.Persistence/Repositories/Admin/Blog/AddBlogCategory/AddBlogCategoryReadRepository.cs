using BetelgeuseAPI.Application.Repositories.Admin.AddBlogCategory;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Admin.Blog.AddBlogCategory;

public class AddBlogCategoryReadRepository:ReadRepository<IdentityContext,BlogCategories>,IAddBlogCategoryReadRepository
{
    public AddBlogCategoryReadRepository(IdentityContext context) : base(context)
    {
    }
}