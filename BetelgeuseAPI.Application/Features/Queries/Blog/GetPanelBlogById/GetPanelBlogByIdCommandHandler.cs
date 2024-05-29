using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.GetPanelBlogById;

public class GetPanelBlogByIdCommandHandler:IRequestHandler<GetPanelBlogByIdCommandRequest,GetPanelBlogByIdCommandResponse>
{
    private readonly IBlogService _blogService;

    public GetPanelBlogByIdCommandHandler(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task<GetPanelBlogByIdCommandResponse> Handle(GetPanelBlogByIdCommandRequest request, CancellationToken cancellationToken)
    {
      var result = await _blogService.GetPanelBlogByIdAsync();

      return new GetPanelBlogByIdCommandResponse
      {
            Data = result.Data.Data,
            Succeeded = result.Succeeded,
            Message = result.Message
        };
    }
}