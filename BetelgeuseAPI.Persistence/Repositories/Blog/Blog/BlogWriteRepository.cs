using BetelgeuseAPI.Application.Repositories.Blog.CreateBlog;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BetelgeuseAPI.Persistence.Repositories.Blog.CreateBlog;

public class BlogWriteRepository : WriteRepository<IdentityContext, Domain.Entities.Blogs>, IBlogWriteRepository
{
    public readonly IdentityContext _context;
    public BlogWriteRepository(IdentityContext context) : base(context)
    {
        _context = context;
    }


    public async Task IncrementViewCount(Guid blogId, HttpContext httpContext)
    {
        var blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == blogId);
        var ipAddress = httpContext.Connection.RemoteIpAddress.ToString();

        // Cookie'den benzersiz ziyaretçi bilgisini kontrol et
        var visitorCookie = httpContext.Request.Cookies["VisitorId"] ?? Guid.NewGuid().ToString();
        var existingVisit = await _context.BlogVisits
            .AnyAsync(bv => bv.BlogId == blogId &&
                            (bv.IpAddress == ipAddress ||
                             httpContext.Request.Cookies["VisitorId"] == visitorCookie));

        if (blog != null && !existingVisit)
        {
            blog.ViewCount++;
            await _context.BlogVisits.AddAsync(new BlogVisit
            {
                BlogId = blogId,
                IpAddress = ipAddress,
                VisitTime = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();

            // Ziyaretçi için cookie ayarla
            var cookieOptions = new CookieOptions { Expires = DateTime.UtcNow.AddDays(30) };
            httpContext.Response.Cookies.Append("VisitorId", visitorCookie, cookieOptions);
        }
    }
}