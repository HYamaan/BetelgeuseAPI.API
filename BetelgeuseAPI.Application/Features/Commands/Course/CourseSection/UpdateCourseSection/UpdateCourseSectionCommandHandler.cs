using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.CourseSection.UpdateCourseSection;

public class UpdateCourseSectionCommandHandler:IRequestHandler<UpdateCourseSectionCommandRequest, UpdateCourseSectionCommandResponse>
{
    private readonly ICourseService _courseService;

    public UpdateCourseSectionCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<UpdateCourseSectionCommandResponse> Handle(UpdateCourseSectionCommandRequest request, CancellationToken cancellationToken)
    {
       var result = await _courseService.UpdateCourseSection(request);

       return new UpdateCourseSectionCommandResponse()
       {
           Message = result.Message,
           Succeeded = result.Succeeded
       };
    }
}