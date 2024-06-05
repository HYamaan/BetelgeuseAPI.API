using BetelgeuseAPI.Application.DTOs.Response.Course.Faq;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Course.FAQSection.GetCourseLogo;

public class GetCourseLogoQueryResponse:ResponseMessageAndSucceeded
{
  public List<CourseLogoResponseDto> Data { get; set; }
}