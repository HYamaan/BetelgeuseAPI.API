using BetelgeuseAPI.Application.DTOs.Response.Course.Faq;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Course.FAQSection.GetCourseFaq;

public class GetCourseFaqQueryResponse : ResponseMessageAndSucceeded
{
    public List<CourseFaqResponseDto> Data { get; set; }
}