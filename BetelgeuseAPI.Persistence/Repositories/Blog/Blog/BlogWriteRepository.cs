using BetelgeuseAPI.Application.Repositories.Blog.CreateBlog;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Blog.CreateBlog;

public class BlogWriteRepository:WriteRepository<IdentityContext,Domain.Entities.Blogs>,IBlogWriteRepository
{
    public BlogWriteRepository(IdentityContext context) : base(context)
    {
    }
}