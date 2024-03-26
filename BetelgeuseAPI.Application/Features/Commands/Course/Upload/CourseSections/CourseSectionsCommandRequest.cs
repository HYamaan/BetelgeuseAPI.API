using BetelgeuseAPI.Domain.Enum;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseSections;

public class CourseSectionsCommandRequest : IRequest<CourseSectionsCommandResponse>
{
    public Guid CourseId { get; set; }
    public Languages LanguageId { get; set; }
    public string Title { get; set; }
    public bool IsActive { get; set; }
    public bool PassAllParts { get; set; }
}