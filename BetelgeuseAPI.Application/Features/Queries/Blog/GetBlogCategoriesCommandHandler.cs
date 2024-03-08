using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Blog;

public class GetBlogCategoriesCommandHandler:IRequestHandler<GetBlogCategoriesCommandRequest, GetBlogCategoriesCommandResponse>
{
    private readonly IBlogService _blogService;

    public GetBlogCategoriesCommandHandler(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task<GetBlogCategoriesCommandResponse> Handle(GetBlogCategoriesCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _blogService.GetBlogCategoriesAsync();

        return new GetBlogCategoriesCommandResponse()
        {
            Data = result.Data.Data,
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}