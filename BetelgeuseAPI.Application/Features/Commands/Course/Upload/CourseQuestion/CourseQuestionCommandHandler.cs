using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseQuestion;

public class CourseQuestionCommandHandler:IRequestHandler<CourseQuestionCommandRequest, CourseQuestionCommandResponse>
{
    private readonly ICourseService _courseService;

    public CourseQuestionCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<CourseQuestionCommandResponse> Handle(CourseQuestionCommandRequest request, CancellationToken cancellationToken)
    {
       var response = await _courseService.AddCourseQuestion(request);

       return new CourseQuestionCommandResponse()
       {
           Message = response.Message,
           Succeeded = response.Succeeded
       };
    }
}