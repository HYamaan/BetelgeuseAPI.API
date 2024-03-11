using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Features.Queries.Blog.BlogByUser;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.GetAllBlogs;

public class GetAllBlogsCommandHandler:IRequestHandler<GetAllBlogsCommandRequest, GetAllBlogsCommandResponse>
{
    private readonly IBlogService _blogService;

    public GetAllBlogsCommandHandler(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task<GetAllBlogsCommandResponse> Handle(GetAllBlogsCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _blogService.GetAllBlogsAsync();
        return new GetAllBlogsCommandResponse()
        {
            Data = result.Data.Data,
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}