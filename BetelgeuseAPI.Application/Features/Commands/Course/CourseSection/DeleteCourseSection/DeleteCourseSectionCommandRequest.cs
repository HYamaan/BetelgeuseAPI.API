using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.CourseSection.DeleteCourseSection;

public class DeleteCourseSectionCommandRequest : IRequest<DeleteCourseSectionCommandResponse>
{
    public string SectionId { get; set; }
}