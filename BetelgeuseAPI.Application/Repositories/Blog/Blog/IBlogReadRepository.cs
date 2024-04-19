using BetelgeuseAPI.Application.DTOs.Response.Blog;
using BetelgeuseAPI.Domain.Entities;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BetelgeuseAPI.Application.Repositories.Blog.CreateBlog;

public interface IBlogReadRepository:IReadRepository<Domain.Entities.Blogs>
{
    IQueryable<BlogResponseDto> GetFilteredBlogs(Expression<Func<Blogs, bool>> filterExpression);
    IQueryable<BlogAllResponseDto> GetBlogs(Expression<Func<Blogs, bool>> filterExpression);
    Task<string> BlogUrlControl(string url);
}