using BetelgeuseAPI.Domain.Common;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Content.DeleteCourseSource;

public class DeleteCourseSourceCommandRequest:IRequest<DeleteCourseSourceCommandResponse>
{
    public Guid SourceId { get; set; }
}