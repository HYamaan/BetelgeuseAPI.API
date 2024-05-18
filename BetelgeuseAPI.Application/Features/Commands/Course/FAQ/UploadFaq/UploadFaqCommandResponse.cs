using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadFaq;

public class UploadFaqCommandResponse:ResponseMessageAndSucceeded
{
    public Guid FaqId { get; set; }
}