using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetCourseDetailPage;

public class GetCourseDetailPageCommandHandler:IRequestHandler<GetCourseDetailPageCommandRequest, GetCourseDetailPageCommandResponse>
{

    private readonly ICourseService _courseService;

    public GetCourseDetailPageCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<GetCourseDetailPageCommandResponse> Handle(GetCourseDetailPageCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _courseService.GetCourseDetailPage(request);
        return new GetCourseDetailPageCommandResponse
        {
            Data=result.Data?.Data,
            Succeeded = true,
            Message = "Course detail page fetched successfully"
        };
    }
}