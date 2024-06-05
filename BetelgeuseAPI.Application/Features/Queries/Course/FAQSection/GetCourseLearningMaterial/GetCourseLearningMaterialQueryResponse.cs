using BetelgeuseAPI.Application.DTOs.Response.Course.Faq;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Course.FAQSection.GetCourseLearningMaterial;

public class GetCourseLearningMaterialQueryResponse : ResponseMessageAndSucceeded
{
    public List<CourseLearningMaterialResponseDto> Data { get; set; }
}
