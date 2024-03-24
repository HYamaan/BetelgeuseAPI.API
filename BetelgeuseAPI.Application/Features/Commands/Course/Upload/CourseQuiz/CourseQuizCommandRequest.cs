using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseQuizes;

public class CourseQuizCommandRequest:IRequest<CourseQuizCommandResponse>
{
    public Guid Language { get; set; }
    public Guid SectionId { get; set; }
    public required string Title { get; set; }
    public int? Time { get; set; }
    public int? Attempts { get; set; }
    public required int PassingScore { get; set; }
    public int? ExpiryDate { get; set; }

    public bool LimitedQuestion { get; set; }
    public int? QuestionCount { get; set; }
    public bool RandomizeQuestion { get; set; }
    public bool Certificate { get; set; }
    public bool IsActive { get; set; }

}