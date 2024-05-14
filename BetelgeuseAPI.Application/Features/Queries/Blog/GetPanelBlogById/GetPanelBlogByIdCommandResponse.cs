using BetelgeuseAPI.Application.DTOs.Response.Blog;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.GetPanelBlogById;

public class GetPanelBlogByIdCommandResponse:ResponseMessageAndSucceeded
{
    public List<GetPanelBlogByIdResponseDTO> Data { get; set; }
}