using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadFaq;

public class UploadFaqCommandHandler: IRequestHandler<UploadFaqCommandRequest, UploadFaqCommandResponse>
{
    private readonly ICourseService _courseService;

    public UploadFaqCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<UploadFaqCommandResponse> Handle(UploadFaqCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _courseService.UploadFaq(request);

        return new UploadFaqCommandResponse()
        {
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}