using BetelgeuseAPI.Application.Repositories.FileContent.BlogImage;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Blog.BlogImage;

public class BlogImageWriteRepository:WriteRepository<IdentityContext,Domain.Entities.File.BlogImage>,IBlogImageWriteRepository
{
    public BlogImageWriteRepository(IdentityContext context) : base(context)
    {
    }
}