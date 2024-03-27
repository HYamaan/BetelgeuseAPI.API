using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Content.CourseTypeOrder;

public class CourseTypeOrderCommandHandler:IRequestHandler<CourseTypeOrderCommandRequest, CourseTypeOrderCommandResponse>
{
    private readonly ICourseService _courseService;

    public CourseTypeOrderCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<CourseTypeOrderCommandResponse> Handle(CourseTypeOrderCommandRequest request, CancellationToken cancellationToken)
    {
       var result = await _courseService.UpdateCourseTypeOrder(request);
       return new CourseTypeOrderCommandResponse()
       {
           Message = result.Message,
           Succeeded = result.Succeeded
       };
    }
}