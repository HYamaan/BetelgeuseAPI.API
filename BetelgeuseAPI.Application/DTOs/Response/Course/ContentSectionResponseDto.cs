using BetelgeuseAPI.Domain.Entities.Course.Content.Quiz;
using BetelgeuseAPI.Domain.Entities.Course.Content;
using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Application.DTOs.Response.Course;

public class ContentSectionResponseDto
{
    public Guid Id { get; set; }
    public Languages LanguageId { get; set; }
    public string Title { get; set; }
    public bool IsActive { get; set; }
    public bool PassAllParts { get; set; }
    public List<ContentSourceResponseDto>? CourseSources { get; set; }
    public List<ContentQuizResponseDto>? CourseQuizzes { get; set; }
}