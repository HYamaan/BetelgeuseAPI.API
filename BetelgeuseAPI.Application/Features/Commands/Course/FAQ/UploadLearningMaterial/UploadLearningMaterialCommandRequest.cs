using BetelgeuseAPI.Domain.Enum;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadLearningMaterial;

public class UploadLearningMaterialCommandRequest:IRequest<UploadLearningMaterialCommandResponse>
{
    public int Order { get; set; }
    public Guid CourseId { get; set; }
    public Languages LanguageId { get; set; }
    public string Title { get; set; }

}