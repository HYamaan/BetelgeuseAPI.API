using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Admin.Course.CourseControl;

public class CoursePublishedCommandRequest:IRequest<CoursePublishedCommandResponse>
{
    public Guid CourseId { get; set; }
    public bool Published { get; set; }
}