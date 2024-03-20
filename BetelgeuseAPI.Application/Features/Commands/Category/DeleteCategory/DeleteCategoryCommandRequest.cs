using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Category.DeleteCategory;

public class DeleteCategoryCommandRequest:IRequest<DeleteCategoryCommandResponse>
{
    public Guid Id { get; set; }
}