using BetelgeuseAPI.Application.DTOs.Response.Blog;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.BlogByPagination;

public class GetBlogByPaginationCommandResponse:ResponseMessageAndSucceeded
{
    public List<BlogResponseDto> Data { get; set; }
}