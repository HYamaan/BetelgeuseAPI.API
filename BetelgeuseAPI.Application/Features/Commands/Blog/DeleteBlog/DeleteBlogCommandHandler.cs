using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Blog.DeleteBlog;

public class DeleteBlogCommandHandler:IRequestHandler<DeleteBlogCommandRequest, DeleteBlogCommandResponse>
{
    private readonly IBlogService _blogService;

    public DeleteBlogCommandHandler(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task<DeleteBlogCommandResponse> Handle(DeleteBlogCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _blogService.DeleteBlog(request);

        return new DeleteBlogCommandResponse()
        {
            Message = response.Message,
            Succeeded = response.Succeeded
        };
    }
}