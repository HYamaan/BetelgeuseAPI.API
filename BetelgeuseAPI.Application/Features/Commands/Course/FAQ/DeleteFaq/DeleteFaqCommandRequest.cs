using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.DeleteFaq;

public class DeleteFaqCommandRequest:IRequest<DeleteFaqCommandResponse>
{
    public Guid CourseId { get; set; }
    public Guid FaqId { get; set; }
}