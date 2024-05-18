using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.FAQSection.GetCourseLearningMaterial;

public class GetCourseLearningMaterialQueryRequest : IRequest<GetCourseLearningMaterialQueryResponse>
{
    public Guid CourseId { get; set; }
}