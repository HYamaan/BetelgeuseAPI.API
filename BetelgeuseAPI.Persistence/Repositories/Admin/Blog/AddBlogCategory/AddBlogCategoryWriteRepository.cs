using BetelgeuseAPI.Application.Repositories.Admin.AddBlogCategory;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Admin.Blog.AddBlogCategory;

public class AddBlogCategoryWriteRepository:WriteRepository<IdentityContext,BlogCategories>,IAddBlogCategoryWriteRepository
{
    public AddBlogCategoryWriteRepository(IdentityContext context) : base(context)
    {
    }
}