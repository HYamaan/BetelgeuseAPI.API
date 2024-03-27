using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.DeleteFaqLearningMaterial;

public class DeleteFaqLearningMaterialCommandHandler:IRequestHandler<DeleteFaqLearningMaterialCommandRequest, DeleteFaqLearningMaterialCommandResponse>
{
    private readonly ICourseService _courseService;

    public DeleteFaqLearningMaterialCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<DeleteFaqLearningMaterialCommandResponse> Handle(DeleteFaqLearningMaterialCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _courseService.DeleteFaqLearningMaterial(request);

        return new DeleteFaqLearningMaterialCommandResponse()
        {
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}