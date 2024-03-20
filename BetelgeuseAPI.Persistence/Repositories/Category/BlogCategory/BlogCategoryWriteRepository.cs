using BetelgeuseAPI.Application.Repositories.Category.BlogCategory;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Category.BlogCategory;

public class BlogCategoryWriteRepository:WriteRepository<IdentityContext,Domain.Entities.Category.BlogCategory>, IBlogCategoryWriteRepository
{
    public BlogCategoryWriteRepository(IdentityContext context) : base(context)
    {
    }
}