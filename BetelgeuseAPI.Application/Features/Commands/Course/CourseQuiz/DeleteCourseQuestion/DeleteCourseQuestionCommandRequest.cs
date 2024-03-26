using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.DeleteCourseQuestion;

public class DeleteCourseQuestionCommandRequest:IRequest<DeleteCourseQuestionCommandResponse>
{
    public Guid questionId { get; set; }
}