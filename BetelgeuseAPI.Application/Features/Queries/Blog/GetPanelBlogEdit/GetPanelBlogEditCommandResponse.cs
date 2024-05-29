using BetelgeuseAPI.Application.DTOs.Response.Blog;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.GetPanelBlogEdit;

public class GetPanelBlogEditCommandResponse :ResponseMessageAndSucceeded
{
     public GetPanelBlogEditResponseDTO Data { get; set; }

}