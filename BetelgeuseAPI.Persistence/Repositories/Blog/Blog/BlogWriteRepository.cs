using BetelgeuseAPI.Application.Repositories.Blog.CreateBlog;
using BetelgeuseAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BetelgeuseAPI.Persistence.Repositories.Blog.CreateBlog;

public class BlogWriteRepository : WriteRepository<IdentityContext, Domain.Entities.Blogs>, IBlogWriteRepository
{
    public readonly IdentityContext _context;
    public BlogWriteRepository(IdentityContext context) : base(context)
    {
        _context = context;
    }


    public async Task IncrementViewCount(Guid blogId)
    {
        var blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == blogId);
        if (blog != null)
        {
            blog.ViewCount++;
            await _context.SaveChangesAsync();
        }
    }

}