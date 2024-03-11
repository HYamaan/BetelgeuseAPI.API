using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Blog.DeleteBlogCategory;

public class DeleteBlogCategoryCommandRequest : IRequest<DeleteBlogCategoryCommandResponse>
{
    public required string Id { get; set; }
}