using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetCourseLearningPage;

public class GetCourseLearningPageCommandRequest:IRequest<GetCourseLearningPageCommandResponse>
{
    public Guid CourseId { get; set; }
}