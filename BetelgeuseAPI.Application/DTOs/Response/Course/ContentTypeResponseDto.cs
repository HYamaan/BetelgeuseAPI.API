namespace BetelgeuseAPI.Application.DTOs.Response.Course;

public class ContentTypeResponseDto
{
    public Guid Id { get; set; }
    public int Order { get; set; }

    public ContentSourceResponseDto? CourseSources { get; set; }
    public ContentQuizResponseDto? CourseQuizzes { get; set; }
}