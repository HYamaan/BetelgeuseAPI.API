using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Delete.DeleteCourseSection;

public class DeleteCourseSectionCommandRequest : IRequest<DeleteCourseSectionCommandResponse>
{
    public string SectionId { get; set; }
}