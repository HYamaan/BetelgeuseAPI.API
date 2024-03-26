using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.CourseQuestion.UpdateCourseQuestion;

public class
    UpdateCourseQuestionCommandHandler : IRequestHandler<UpdateCourseQuestionCommandRequest,
        UpdateCourseQuestionCommandResponse>
{
    private readonly ICourseService _courseService;

    public UpdateCourseQuestionCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<UpdateCourseQuestionCommandResponse> Handle(UpdateCourseQuestionCommandRequest request,
        CancellationToken cancellationToken)
    {
       var result = await _courseService.UpdateCourseQuestion(request);

       return new UpdateCourseQuestionCommandResponse()
       {
           Message = result.Message,
           Succeeded = result.Succeeded
       };
    }
}