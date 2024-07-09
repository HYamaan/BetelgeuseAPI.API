using BetelgeuseAPI.Application.DTOs.Response.Course.Faq;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Course.FAQSection.GetRequirements;

public class GetRequirementsQueryResponse:ResponseMessageAndSucceeded
{
    public List<CourseRequirementsResponseDto> Data { get; set; }
}