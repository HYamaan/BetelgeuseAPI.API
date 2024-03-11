using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.BlogByPagination;

public class GetBlogByPaginationCommandRequest: IRequest<GetBlogByPaginationCommandResponse>
{
    public string Index { get; set; }
}