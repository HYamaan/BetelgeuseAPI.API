using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.CourseSection.DeleteCourseSection;

public class DeleteCourseSectionCommandHandler : IRequestHandler<DeleteCourseSectionCommandRequest, DeleteCourseSectionCommandResponse>
{
    private readonly ICourseService _courseService;

    public DeleteCourseSectionCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<DeleteCourseSectionCommandResponse> Handle(DeleteCourseSectionCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _courseService.DeleteCourseSection(request);

        return new DeleteCourseSectionCommandResponse()
        {
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}