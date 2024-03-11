using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Domain.Common;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Blog.DeleteBlogCategory;

public class DeleteBlogCategoryCommandHandler : IRequestHandler<DeleteBlogCategoryCommandRequest, DeleteBlogCategoryCommandResponse>
{
    private readonly IBlogService _blogService;

    public DeleteBlogCategoryCommandHandler(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task<DeleteBlogCategoryCommandResponse> Handle(DeleteBlogCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _blogService.DeleteBlogCategory(request);
        return new DeleteBlogCategoryCommandResponse()
        {
            Succeeded = response.Succeeded,
            Message = response.Message
        };
    }
}