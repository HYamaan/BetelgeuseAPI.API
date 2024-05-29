using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.BlogByPagination;

public class GetBlogByPaginationCommandHandler: IRequestHandler<GetBlogByPaginationCommandRequest, GetBlogByPaginationCommandResponse>
{
    private readonly IBlogService _blogService;

    public GetBlogByPaginationCommandHandler(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task<GetBlogByPaginationCommandResponse> Handle(GetBlogByPaginationCommandRequest request, CancellationToken cancellationToken)
    {
        request.Index = request.Index - 1;
        var result = await _blogService.GetBlogByPaginationAsync(request);

        return new GetBlogByPaginationCommandResponse
        {
            Succeeded = result.Succeeded,
            Message = result.Message,
            Data = result.Data?.Data
        };
    }
}