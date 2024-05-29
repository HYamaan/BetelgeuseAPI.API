using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetCourseDetailPage;

public class GetCourseDetailPageCommandRequest:IRequest<GetCourseDetailPageCommandResponse>
{
    public Guid CourseId { get; set; }
}