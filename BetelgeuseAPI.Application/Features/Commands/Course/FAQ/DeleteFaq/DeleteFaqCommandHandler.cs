using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.DeleteFaq;

public class DeleteFaqCommandHandler:IRequestHandler<DeleteFaqCommandRequest, DeleteFaqCommandResponse>
{
    private readonly ICourseService _courseService;

    public DeleteFaqCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<DeleteFaqCommandResponse> Handle(DeleteFaqCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _courseService.DeleteFaqOption(request);
        return new DeleteFaqCommandResponse()
        {
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}