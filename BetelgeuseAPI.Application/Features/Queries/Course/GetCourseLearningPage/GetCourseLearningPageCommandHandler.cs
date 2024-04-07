using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetCourseLearningPage;

public class GetCourseLearningPageCommandHandler:IRequestHandler<GetCourseLearningPageCommandRequest, GetCourseLearningPageCommandResponse>
{
    private readonly ICourseService _courseService;

    public GetCourseLearningPageCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<GetCourseLearningPageCommandResponse> Handle(GetCourseLearningPageCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _courseService.GetCourseLearningPage(request);

        return new GetCourseLearningPageCommandResponse()
        {
            Data = result.Data?.Data,
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}