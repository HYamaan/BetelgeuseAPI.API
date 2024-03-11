using BetelgeuseAPI.Application.DTOs.Response.Blog;
using BetelgeuseAPI.Domain.Entities;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BetelgeuseAPI.Application.Repositories.Blog.CreateBlog;

public interface IBlogReadRepository:IReadRepository<Domain.Entities.Blogs>
{
    IQueryable<BlogResponseDto> GetFilteredBlogsAsync(Expression<Func<Blogs, bool>> filterExpression);
    Task<string> BlogUrlControl(string url);
}