using BetelgeuseAPI.Domain.Enum;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadFaq;

public class UploadFaqCommandRequest:IRequest<UploadFaqCommandResponse>
{
    public int Order { get; set; }
    public Guid CourseId { get; set; }
    public Languages LanguageId { get; set; }
    public string Title { get; set; }

    public string Answer { get; set; }
}