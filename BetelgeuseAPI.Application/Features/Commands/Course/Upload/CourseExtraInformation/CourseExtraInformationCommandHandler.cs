using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseExtraInformation;

public class CourseExtraInformationCommandHandler : IRequestHandler<CourseExtraInformationCommandRequest, CourseExtraInformationCommandResponse>
{
    private readonly ICourseService _courseService;

    public CourseExtraInformationCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<CourseExtraInformationCommandResponse> Handle(CourseExtraInformationCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _courseService.AddCourseExtraInformation(request);

        return new CourseExtraInformationCommandResponse()
        {
            Succeeded = result.Succeeded,
            Message = result.Message
        };
    }
}