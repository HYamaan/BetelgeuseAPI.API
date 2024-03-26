using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.UploadCourseQuiz;

public class UploadCourseQuizCommandHandler:IRequestHandler<UploadCourseQuizCommandRequest, UploadCourseQuizCommandResponse>
{
    private readonly ICourseService _courseService;

    public UploadCourseQuizCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<UploadCourseQuizCommandResponse> Handle(UploadCourseQuizCommandRequest request, CancellationToken cancellationToken)
    {
       var result = await _courseService.UploadCourseQuiz(request);
       return new UploadCourseQuizCommandResponse()
       {
           Message = result.Message,
           Succeeded = result.Succeeded
       };
    }
}