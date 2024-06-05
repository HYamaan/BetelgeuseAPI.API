using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadLearningMaterial;

public class UploadLearningMaterialCommandResponse:ResponseMessageAndSucceeded
{
    public Guid Id { get; set; }
}