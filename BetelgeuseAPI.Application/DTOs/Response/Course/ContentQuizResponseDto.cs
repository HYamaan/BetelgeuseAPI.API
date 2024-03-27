
using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Application.DTOs.Response.Course;

public class ContentQuizResponseDto
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public Guid CourseSectionsId { get; set; }
    public Languages Language { get; set; }
    public required string Title { get; set; }
    public int? Time { get; set; }
    public int? Attempts { get; set; }
    public required int PassingScore { get; set; }
    public int? ExpiryDate { get; set; }

    public bool LimitedQuestion { get; set; }
    public int? QuestionCount { get; set; }
    public bool RandomizeQuestion { get; set; }
    public bool Certificate { get; set; }
    public bool IsActive { get; set; }

    public List<ContentQuizQuestionsResponseDto> CourseQuestions { get; set; }

}