using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Features.Queries.Blog.BlogByCategory;
using BetelgeuseAPI.Domain.Common;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.BlogByUser;

public class GetBlogByUserCommandHandler:IRequestHandler<GetBlogByUserCommandRequest, GetBlogByUserCommandResponse>
{
    private readonly IBlogService _blogService;

    public GetBlogByUserCommandHandler(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task<GetBlogByUserCommandResponse> Handle(GetBlogByUserCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _blogService.GetBlogByUserAsync(request);
        return new GetBlogByUserCommandResponse()
        {
            Data = result.Data.Data,
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}