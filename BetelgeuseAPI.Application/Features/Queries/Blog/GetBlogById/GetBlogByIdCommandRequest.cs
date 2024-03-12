using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.GetBlogById;

public class GetBlogByIdCommandRequest:IRequest<GetBlogByIdCommandResponse>
{
    public Guid Id { get; set; }
}