namespace BetelgeuseAPI.Application.Repositories.Blog.CreateBlog;

public interface IBlogWriteRepository:IWriteRepository<Domain.Entities.Blogs>
{
    Task IncrementViewCount(Guid blogId);
}