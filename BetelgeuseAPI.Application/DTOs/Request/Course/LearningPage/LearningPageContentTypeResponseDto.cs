using BetelgeuseAPI.Application.DTOs.Response.Course;

namespace BetelgeuseAPI.Application.DTOs.Request.Course.LearningPage;

public class LearningPageContentTypeResponseDto
{
    public Guid Id { get; set; }
    public int Order { get; set; }

    public LearningPageContentSourceResponseDto? contentSource { get; set; }
    public LearningPageContentQuizzesResponseDto? contetnQuizzes { get; set; }
}