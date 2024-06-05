using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Application.DTOs.Response.Course.Faq;

public class CourseFaqResponseDto
{
    public Guid Id { get; set; }
    public Languages LanguageId { get; set; }
    public string Title { get; set; }
    public string Answer { get; set; }
    public int Order { get; set; }



}