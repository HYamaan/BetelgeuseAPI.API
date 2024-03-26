using BetelgeuseAPI.Domain.Enum;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.CourseSection.UpdateCourseSection;

public class UpdateCourseSectionCommandRequest:IRequest<UpdateCourseSectionCommandResponse>
{
    public Guid CourseId { get; set; }
    public Guid CourseSectionId { get; set; }

    public Languages? LanguageId { get; set; }
    public string? Title { get; set; }
    public bool? IsActive { get; set; }
    public bool? PassAllParts { get; set; }
}