using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.FAQSection.GetCourseFaq;

public class GetCourseFaqQueryHandler : IRequestHandler<GetCourseFaqQueryRequest, GetCourseFaqQueryResponse>
{
    private readonly ICourseService _courseService;

    public GetCourseFaqQueryHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<GetCourseFaqQueryResponse> Handle(GetCourseFaqQueryRequest request, CancellationToken cancellationToken)
    {
        if (request.CourseId == null)
        {
            return new GetCourseFaqQueryResponse()
            {
                Message = "CourseId is required",
                Succeeded = false
            };
        }

        var result = await _courseService.GetCourseFaq(request);

        return new GetCourseFaqQueryResponse()
        {
            Data = result.Data?.Data,
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}