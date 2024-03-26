using BetelgeuseAPI.Domain.Enum;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.UploadCourseQuiz;

public class UploadCourseQuizCommandRequest:IRequest<UploadCourseQuizCommandResponse>
{
    public Guid SectionId { get; set; }
    public Guid QuizId { get; set; }
    public Languages? Language { get; set; }
    public string? Title { get; set; }
    public int? Time { get; set; }
    public int? Attempts { get; set; }
    public int? PassingScore { get; set; }
    public int? ExpiryDate { get; set; }

    public bool? LimitedQuestion { get; set; }
    public int? QuestionCount { get; set; }
    public bool? RandomizeQuestion { get; set; }
    public bool? Certificate { get; set; }
    public bool? IsActive { get; set; }
}