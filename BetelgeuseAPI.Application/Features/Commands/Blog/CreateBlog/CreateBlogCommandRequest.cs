using MediatR;
using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.Features.Commands.Blog.CreateBlog;

public class CreateBlogCommandRequest: IRequest<CreateBlogCommandResponse>
{
    public string Title { get; set; }
    public Guid BlogCategoriesID { get; set; }
    public string? Keywords { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public IFormFile BlogImage { get; set; }

    
}