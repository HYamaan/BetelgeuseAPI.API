using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.FAQSection.GetRequirements;

public class GetRequirementsQueryRequest : IRequest<GetRequirementsQueryResponse>
{
    public Guid CourseId { get; set; }
}
