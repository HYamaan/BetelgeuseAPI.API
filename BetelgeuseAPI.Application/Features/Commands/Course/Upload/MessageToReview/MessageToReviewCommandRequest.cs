using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Upload.MessageToReview;

public class MessageToReviewCommandRequest:IRequest<MessageToReviewCommandResponse>
{
    public Guid CourseId { get; set; }
    public string Message { get; set; }
    public bool Rules { get; set; }
}