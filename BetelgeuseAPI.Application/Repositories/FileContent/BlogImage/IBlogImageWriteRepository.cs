using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.Repositories.FileContent.BlogImage;

public interface IBlogImageWriteRepository : IWriteRepository<Domain.Entities.File.BlogImage>
{
}