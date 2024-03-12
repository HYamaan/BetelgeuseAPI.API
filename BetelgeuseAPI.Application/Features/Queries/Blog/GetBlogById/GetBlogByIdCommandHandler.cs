using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.GetBlogById;

public class GetBlogByIdCommandHandler:IRequestHandler<GetBlogByIdCommandRequest,GetBlogByIdCommandResponse>
{
    private readonly IBlogService _blogService;

    public GetBlogByIdCommandHandler(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task<GetBlogByIdCommandResponse> Handle(GetBlogByIdCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _blogService.GetBlogById(request);
        return new GetBlogByIdCommandResponse
        {
            Data = result.Data.Data,
            Succeeded = result.Succeeded,
            Message = result.Message
        };
    }
}