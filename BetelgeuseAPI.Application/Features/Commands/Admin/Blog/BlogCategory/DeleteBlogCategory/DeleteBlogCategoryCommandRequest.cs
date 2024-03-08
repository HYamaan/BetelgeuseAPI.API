using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Admin.Blog.BlogCategory.DeleteBlogCategory;

public class DeleteBlogCategoryCommandRequest:IRequest<DeleteBlogCategoryCommandResponse>
{
    public required string Id { get; set; }
}