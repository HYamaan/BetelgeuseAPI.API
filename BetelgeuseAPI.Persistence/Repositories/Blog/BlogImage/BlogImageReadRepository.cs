using BetelgeuseAPI.Application.Repositories.FileContent.BlogImage;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Blog.BlogImage;

public class BlogImageReadRepository:ReadRepository<IdentityContext,Domain.Entities.File.BlogImage>, IBlogImageReadRepository
{
    public BlogImageReadRepository(IdentityContext context) : base(context)
    {
    }
}