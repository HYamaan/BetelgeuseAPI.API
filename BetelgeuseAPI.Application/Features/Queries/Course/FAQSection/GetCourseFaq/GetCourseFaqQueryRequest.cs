using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.FAQSection.GetCourseFaq;

public class GetCourseFaqQueryRequest : IRequest<GetCourseFaqQueryResponse>
{
    public Guid CourseId { get; set; }
}