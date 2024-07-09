using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Features.Queries.Course.FAQSection.GetCourseLearningMaterial;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.FAQSection.GetCourseLogo;

public class GetCourseLogoQueryHandler:IRequestHandler<GetCourseLogoQueryRequest,GetCourseLogoQueryResponse>
{
    private readonly ICourseService _courseService;

    public GetCourseLogoQueryHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<GetCourseLogoQueryResponse> Handle(GetCourseLogoQueryRequest request, CancellationToken cancellationToken)
    {
        if (request.CourseId == null)
        {
            return new GetCourseLogoQueryResponse()
            {
                Message = "CourseId is required",
                Succeeded = false
            };
        }

        var result = await _courseService.GetCourseLogo(request);
        return new GetCourseLogoQueryResponse()
        {
            Data = result.Data.Data,
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}