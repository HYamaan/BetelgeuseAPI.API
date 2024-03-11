using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.Repositories.Blog.BlogImage;

public interface IBlogImageWriteRepository:IWriteRepository<Domain.Entities.BlogImage>
{
}