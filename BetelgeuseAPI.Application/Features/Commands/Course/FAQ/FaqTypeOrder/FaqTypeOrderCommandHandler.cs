using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.FaqTypeOrder;

public class FaqTypeOrderCommandHandler:IRequestHandler<FaqTypeOrderCommandRequest, FaqTypeOrderCommandResponse>
{
    private readonly ICourseService _courseService;

    public FaqTypeOrderCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<FaqTypeOrderCommandResponse> Handle(FaqTypeOrderCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _courseService.UpdateFaqTypeOrder(request);
        return new FaqTypeOrderCommandResponse()
        {
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}