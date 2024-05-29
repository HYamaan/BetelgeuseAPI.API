using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Application.DTOs.Response.Course;

public class CourseLearningMaterialResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Order { get; set; }
    public Languages LanguageId { get; set; }
}