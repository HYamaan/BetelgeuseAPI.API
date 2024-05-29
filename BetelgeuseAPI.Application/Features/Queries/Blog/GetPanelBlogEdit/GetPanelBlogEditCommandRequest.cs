using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.GetPanelBlogEdit;

public class GetPanelBlogEditCommandRequest: IRequest<GetPanelBlogEditCommandResponse>
{
    public Guid Id { get; set; }
}