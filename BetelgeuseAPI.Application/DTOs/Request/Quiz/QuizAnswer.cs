using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.DTOs.Request.Quiz;

public class QuizAnswer
{
    public string? Title { get; set; }
    public bool? IsCorrect { get; set; }
    public string? Description { get; set; }

}