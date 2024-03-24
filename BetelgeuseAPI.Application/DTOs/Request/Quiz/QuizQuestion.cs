using BetelgeuseAPI.Domain.Entities.Course.Content.Quiz;
using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.DTOs.Request.Quiz;

public class QuizQuestion
{
    public required Guid LanguageId { get; set; }
    public required string Title { get; set; }
    public required int Grade { get; set; }
    public IFormFile? Image { get; set; }
    public IFormFile? Video { get; set; }
    public required  List<QuizAnswer>? QuizAnswers { get; set; }
}