using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.FAQSection.GetCourseLearningMaterial;

public class GetCourseLearningMaterialQueryHandler : IRequestHandler<GetCourseLearningMaterialQueryRequest, GetCourseLearningMaterialQueryResponse>
{
    private readonly ICourseService _courseService;

    public GetCourseLearningMaterialQueryHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<GetCourseLearningMaterialQueryResponse> Handle(GetCourseLearningMaterialQueryRequest request, CancellationToken cancellationToken)
    {
        if (request.CourseId == null)
        {
            return new GetCourseLearningMaterialQueryResponse()
            {
                Message = "CourseId is required",
                Succeeded = false
            };
        }

        var result = await _courseService.GetCourseLearningMaterial(request);
        return new GetCourseLearningMaterialQueryResponse()
        {
            Data = result.Data.Data,
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}