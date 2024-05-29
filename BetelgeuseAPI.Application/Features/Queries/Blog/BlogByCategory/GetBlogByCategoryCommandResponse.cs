using BetelgeuseAPI.Application.DTOs.Response.Blog;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.BlogByCategory;

public class GetBlogByCategoryCommandResponse:ResponseMessageAndSucceeded
{
    public List<BlogAllResponseDto> Data { get; set; }
}