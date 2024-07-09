using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Application.DTOs.Response.Course.Faq;

public class CourseRequirementsResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Order { get; set; }
    public Languages LanguageId { get; set; }
}