using BetelgeuseAPI.Application.Repositories.Blog.BlogImage;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Blog.BlogImage;

public class BlogImageWriteRepository:WriteRepository<IdentityContext,Domain.Entities.BlogImage>,IBlogImageWriteRepository
{
    public BlogImageWriteRepository(IdentityContext context) : base(context)
    {
    }
}