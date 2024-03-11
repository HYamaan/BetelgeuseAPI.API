using BetelgeuseAPI.Application.Repositories.Category.BlogCategory;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Category.BlogCategory;

public class BlogCategoryReadRepository:ReadRepository<IdentityContext,Domain.Entities.BlogCategory>, IBlogCategoryReadRepository
{
    public BlogCategoryReadRepository(IdentityContext context) : base(context)
    {
    }
}