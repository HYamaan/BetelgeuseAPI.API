using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.FAQSection.GetCourseLogo;

public class GetCourseLogoQueryRequest:IRequest<GetCourseLogoQueryResponse>
{
    public Guid CourseId { get; set; }
}