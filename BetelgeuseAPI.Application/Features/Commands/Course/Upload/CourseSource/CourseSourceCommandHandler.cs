using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;
using Org.BouncyCastle.Asn1.Ocsp;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseSource;

public class CourseSourceCommandHandler:IRequestHandler<CourseSourceCommandRequest,CourseSourceCommandResponse>
{
    private readonly ICourseService _courseService;

    public CourseSourceCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<CourseSourceCommandResponse> Handle(CourseSourceCommandRequest request, CancellationToken cancellationToken)
    {
        
        var result = await _courseService.AddCourseSource(request);

        return new CourseSourceCommandResponse()
        {
            Message = result.Message,
            Succeeded = result.Succeeded
        };

    }
}