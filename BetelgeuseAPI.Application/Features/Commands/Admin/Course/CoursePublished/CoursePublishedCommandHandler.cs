using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Admin.Course.CourseControl;

public class CoursePublishedCommandHandler:IRequestHandler<CoursePublishedCommandRequest,CoursePublishedCommandResponse>
{
    private readonly IAdminService _adminService;

    public CoursePublishedCommandHandler(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public async Task<CoursePublishedCommandResponse> Handle(CoursePublishedCommandRequest request, CancellationToken cancellationToken)
    {
       var result = await _adminService.CoursePublished(request);
       return new CoursePublishedCommandResponse()
       {
              Message = result.Message,
              Succeeded = result.Succeeded
         };
    }
}