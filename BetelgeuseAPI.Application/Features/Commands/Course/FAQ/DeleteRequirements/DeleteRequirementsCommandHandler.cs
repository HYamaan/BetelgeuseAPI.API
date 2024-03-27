using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.DeleteRequirements;

public class DeleteRequirementsCommandHandler:IRequestHandler<DeleteRequirementsCommandRequest, DeleteRequirementsCommandResponse>
{
    private readonly ICourseService _courseService;

    public DeleteRequirementsCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<DeleteRequirementsCommandResponse> Handle(DeleteRequirementsCommandRequest request, CancellationToken cancellationToken)
    {
       var result = await _courseService.DeleteRequirements(request);
       return new DeleteRequirementsCommandResponse()
       {
           Message = result.Message,
           Succeeded = result.Succeeded
       };
    }
}