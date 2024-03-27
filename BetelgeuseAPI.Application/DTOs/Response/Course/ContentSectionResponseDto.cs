using BetelgeuseAPI.Domain.Entities.Course.Content.Quiz;
using BetelgeuseAPI.Domain.Entities.Course.Content;
using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Application.DTOs.Response.Course;

public class ContentSectionResponseDto
{
    public int Order { get; set; }
    public Guid Id { get; set; }
    public Languages LanguageId { get; set; }
    public string Title { get; set; }
    public bool IsActive { get; set; }
    public bool PassAllParts { get; set; }
    public List<ContentTypeResponseDto>? CourseTypes { get; set; }
}