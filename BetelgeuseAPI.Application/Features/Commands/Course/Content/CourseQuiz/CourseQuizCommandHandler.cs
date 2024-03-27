using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Content.CourseQuiz;

public class CourseQuizCommandHandler : IRequestHandler<CourseQuizCommandRequest, CourseQuizCommandResponse>
{
    private readonly ICourseService _courseService;

    public CourseQuizCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<CourseQuizCommandResponse> Handle(CourseQuizCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _courseService.AddCourseQuiz(request);

        return new CourseQuizCommandResponse()
        {
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}