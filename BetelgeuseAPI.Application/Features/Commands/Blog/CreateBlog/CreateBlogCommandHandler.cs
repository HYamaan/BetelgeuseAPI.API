using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Blog.CreateBlog;

public class CreateBlogCommandHandler:IRequestHandler<CreateBlogCommandRequest, CreateBlogCommandResponse>
{
    public readonly IBlogService _blogService;

    public CreateBlogCommandHandler(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task<CreateBlogCommandResponse> Handle(CreateBlogCommandRequest request, CancellationToken cancellationToken)
    {
       var response = await _blogService.CreateBlog(request);
       return new CreateBlogCommandResponse()
       {
           Succeeded = response.Succeeded,
           Message = response.Message
       };
    }
}