namespace BetelgeuseAPI.Application.DTOs.Response.Course.CourseDetail;

public class ContentQuizzesTypeResponseDto
{
    public int QuestionCount { get; set; }
    public int Duration { get; set; }
    public int Grade { get; set; }
    public int? AttemptCount { get; set; }
}