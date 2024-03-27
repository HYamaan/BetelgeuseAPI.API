using BetelgeuseAPI.Domain.Enum;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Content.CourseSections;

public class CourseSectionsCommandRequest : IRequest<CourseSectionsCommandResponse>
{
    public int Order { get; set; }
    public Guid CourseId { get; set; }
    public Languages LanguageId { get; set; }
    public string Title { get; set; }
    public bool IsActive { get; set; }
    public bool PassAllParts { get; set; }
}