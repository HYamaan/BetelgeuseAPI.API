using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.GetPanelBlogEdit;

public class GetPanelBlogEditCommandHandler:IRequestHandler<GetPanelBlogEditCommandRequest, GetPanelBlogEditCommandResponse>
{
    private readonly IBlogService _blogService;

    public GetPanelBlogEditCommandHandler(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task<GetPanelBlogEditCommandResponse> Handle(GetPanelBlogEditCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _blogService.GetPanelBlogEditAsync(request);

        return new GetPanelBlogEditCommandResponse()
        {
            Data = result.Data?.Data,
            Succeeded = result.Succeeded,
            Message = result.Message
        };
    }
    
}