namespace BetelgeuseAPI.Application.DTOs.Response.Course;

public class ContentQuizAnswerResponseDto
{
    public string? Title { get; set; }
    public bool? IsCorrect { get; set; }


    public string? Description { get; set; }

    public Guid CourseQuestionId { get; set; }
}