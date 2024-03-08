using BetelgeuseAPI.Application.Repositories.Blog.CreateBlog;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Blog.CreateBlog;

public class BlogReadRepository : ReadRepository<IdentityContext, Domain.Entities.Blogs>,
    IBlogReadRepository
{
    public BlogReadRepository(IdentityContext context) : base(context)
    {
    }
}