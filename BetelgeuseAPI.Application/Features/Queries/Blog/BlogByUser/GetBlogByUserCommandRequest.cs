using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.BlogByUser;

public class GetBlogByUserCommandRequest:IRequest<GetBlogByUserCommandResponse>
{
    public string Id { get; set; }
}