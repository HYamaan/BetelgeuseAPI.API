using BetelgeuseAPI.Domain.Enum;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadRequirements;

public class UploadRequirementsCommandRequest:IRequest<UploadRequirementsCommandResponse>
{
    public int Order { get; set; }
    public Guid CourseId { get; set; }
    public Languages LanguageId { get; set; }
    public string Title { get; set; }
}