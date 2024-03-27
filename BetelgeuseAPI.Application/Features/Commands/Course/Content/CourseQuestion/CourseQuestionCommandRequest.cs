using BetelgeuseAPI.Application.DTOs.Request.Course.Content.Quiz;
using BetelgeuseAPI.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Content.CourseQuestion;

public class CourseQuestionCommandRequest : IRequest<CourseQuestionCommandResponse>
{
    public required Guid quizId { get; set; }
    public required Languages LanguageId { get; set; }
    public CourseQuizQuestionType QuestionType { get; set; }
    public required string Title { get; set; }
    public required int Grade { get; set; }
    public IFormFile? Image { get; set; }
    public IFormFile? Video { get; set; }
    public required List<QuizAnswer> QuizAnswers { get; set; }
}