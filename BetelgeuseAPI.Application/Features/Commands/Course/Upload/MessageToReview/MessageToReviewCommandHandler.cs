using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Upload.MessageToReview;

public class MessageToReviewCommandHandler:IRequestHandler<MessageToReviewCommandRequest,MessageToReviewCommandResponse>
{
    private readonly ICourseService _courseService;

    public MessageToReviewCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }
    public async Task<MessageToReviewCommandResponse> Handle(MessageToReviewCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Rules == false)
        {
            return new MessageToReviewCommandResponse()
            {
                Message = "The rules field is required.",
                Succeeded = false
            };
        }
        var result = await _courseService.AddMessageToReview(request);

        return new MessageToReviewCommandResponse()
        {
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}