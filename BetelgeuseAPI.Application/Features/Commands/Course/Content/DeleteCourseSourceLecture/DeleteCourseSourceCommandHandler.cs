using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Domain.Common;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Content.DeleteCourseSource;

public class DeleteCourseSourceCommandHandler: IRequestHandler<DeleteCourseSourceCommandRequest, DeleteCourseSourceCommandResponse>
{
    private readonly ICourseService _courseService;

    public DeleteCourseSourceCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<DeleteCourseSourceCommandResponse> Handle(DeleteCourseSourceCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _courseService.DeleteCourseSource(request);

        return new DeleteCourseSourceCommandResponse()
        {
            Message = result.Message,
            Succeeded = result.Succeeded 
        };
    }
}