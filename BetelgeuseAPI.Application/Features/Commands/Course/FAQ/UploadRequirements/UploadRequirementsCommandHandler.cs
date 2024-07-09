using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadRequirements;

public class UploadRequirementsCommandHandler:IRequestHandler<UploadRequirementsCommandRequest, UploadRequirementsCommandResponse>
{
    private readonly ICourseService _courseService;

    public UploadRequirementsCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<UploadRequirementsCommandResponse> Handle(UploadRequirementsCommandRequest request, CancellationToken cancellationToken)
    {
        var result  = await _courseService.UploadRequirements(request);
        return new UploadRequirementsCommandResponse()
        {
            Id = result.Data.Id,
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}