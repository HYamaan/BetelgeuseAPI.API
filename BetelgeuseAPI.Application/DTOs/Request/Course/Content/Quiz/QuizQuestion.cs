using BetelgeuseAPI.Domain.Entities.Course.Content.Quiz;
using BetelgeuseAPI.Domain.Enum;
using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.DTOs.Request.Course.Content.Quiz;

public class QuizQuestion
{
    public required Languages LanguageId { get; set; }
    public required string Title { get; set; }
    public required int Grade { get; set; }
    public IFormFile? Image { get; set; }
    public IFormFile? Video { get; set; }
    public required List<QuizAnswer>? QuizAnswers { get; set; }
}