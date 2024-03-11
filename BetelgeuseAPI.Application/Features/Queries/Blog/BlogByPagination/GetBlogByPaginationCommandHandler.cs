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
        var result = await _blogService.GetBlogByPaginationAsync(request);

        return new GetBlogByPaginationCommandResponse
        {
            Succeeded = true,
            Message = "Get Blog By Pagination Successfully",
            Data = result.Data.Data
        };
    }
}