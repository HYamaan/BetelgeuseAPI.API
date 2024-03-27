using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.DTOs.Request.Course.Content.Quiz;

public class QuizAnswer
{
    public Guid? Id { get; set; }
    public string? Title { get; set; }
    public bool? IsCorrect { get; set; }
    public string? Description { get; set; }

}