using BetelgeuseAPI.Application.DTOs.Response.Blog;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.BlogByUser;

public class GetBlogByUserCommandResponse:ResponseMessageAndSucceeded
{
    public List<BlogResponseDto> Data { get; set; }
}