
using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.DeleteCourseQuestion
{
    public class DeleteCourseQuestionCommandHandler: IRequestHandler<DeleteCourseQuestionCommandRequest, DeleteCourseQuestionCommandResponse>
    {
        private readonly ICourseService _courseService;

        public DeleteCourseQuestionCommandHandler(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<DeleteCourseQuestionCommandResponse> Handle(DeleteCourseQuestionCommandRequest request, CancellationToken cancellationToken)
        {
           var result = await _courseService.DeleteCourseQuestion(request);
           return new DeleteCourseQuestionCommandResponse()
           {
               Message = result.Message,
               Succeeded = result.Succeeded
           };
        }
    }
}
