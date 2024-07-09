using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadLearningMaterial;

public class UploadLearningMaterialCommandHandler:IRequestHandler<UploadLearningMaterialCommandRequest, UploadLearningMaterialCommandResponse>
{
    private readonly ICourseService _courseService;

    public UploadLearningMaterialCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<UploadLearningMaterialCommandResponse> Handle(UploadLearningMaterialCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _courseService.UploadLearningMaterial(request);

        return new UploadLearningMaterialCommandResponse()
        {
            Id = result.Data.Id,
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}