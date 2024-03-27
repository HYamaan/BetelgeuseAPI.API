using BetelgeuseAPI.Application.DTOs.Request.Course.Content.Quiz;
using BetelgeuseAPI.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.CourseQuestion.UpdateCourseQuestion;

public class UpdateCourseQuestionCommandRequest:IRequest<UpdateCourseQuestionCommandResponse>
{
    public Guid quizId { get; set; }
    public Guid questionId { get; set; }
    public Languages? LanguageId { get; set; }
    public CourseQuizQuestionType? QuestionType { get; set; }
    public  string? Title { get; set; }
    public  int? Grade { get; set; }
    public IFormFile? Image { get; set; }
    public IFormFile? Video { get; set; }
    public  List<QuizAnswer>? QuizAnswers { get; set; }
}