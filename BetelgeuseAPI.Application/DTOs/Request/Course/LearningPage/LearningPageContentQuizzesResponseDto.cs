namespace BetelgeuseAPI.Application.DTOs.Request.Course.LearningPage;

public class LearningPageContentQuizzesResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int? Minutes { get; set; }
    public int? QuestionCount { get; set; }
}