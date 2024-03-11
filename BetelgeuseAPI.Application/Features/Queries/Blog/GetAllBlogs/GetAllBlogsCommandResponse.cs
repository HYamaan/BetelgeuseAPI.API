using BetelgeuseAPI.Application.DTOs.Response.Blog;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.GetAllBlogs;

public class GetAllBlogsCommandResponse:ResponseMessageAndSucceeded
{
    public List<BlogResponseDto> Data { get; set; }
}