using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.QuizInteraction;

public class QuizInteractionCommandRequest:IRequest<QuizInteractionCommandResponse>
{
    public Guid CourseQuizId { get; set; }
    public Guid CourseQuestionId { get; set; }
    public Guid? CourseQuizAnswerId { get; set; }
}