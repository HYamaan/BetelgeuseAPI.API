using BetelgeuseAPI.Application.Repositories.Blog.BlogImage;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Blog.BlogImage;

public class BlogImageReadRepository:ReadRepository<IdentityContext,Domain.Entities.BlogImage>, IBlogImageReadRepository
{
    public BlogImageReadRepository(IdentityContext context) : base(context)
    {
    }
}