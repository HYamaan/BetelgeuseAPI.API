using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.DeleteRequirements;

public class DeleteRequirementsCommandRequest:IRequest<DeleteRequirementsCommandResponse>
{
    public Guid CourseId { get; set; }
    public Guid Id { get; set; }
}