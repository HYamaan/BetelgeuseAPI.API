using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.BlogByCategory;

public class GetBlogByCategoryCommandRequest:IRequest<GetBlogByCategoryCommandResponse>
{
    public Guid CategoryId { get; set; }
}