using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.DeleteFaqLearningMaterial;

public class DeleteFaqLearningMaterialCommandRequest : IRequest<DeleteFaqLearningMaterialCommandResponse>
{
    public required Guid CourseId { get; set; }
    public required Guid Id { get; set; }
}