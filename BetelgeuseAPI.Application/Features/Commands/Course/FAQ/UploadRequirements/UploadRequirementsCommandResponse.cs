using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadRequirements;

public class UploadRequirementsCommandResponse:ResponseMessageAndSucceeded
{
    public Guid Id { get; set; }
}