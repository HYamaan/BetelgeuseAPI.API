using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetContent;

public class GetContentCommandHandler:IRequestHandler<GetContentCommandRequest, GetContentCommandResponse>
{
    private readonly ICourseService _courseService;

    public GetContentCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<GetContentCommandResponse> Handle(GetContentCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _courseService.GetContent(request);

        return new GetContentCommandResponse()
        {
            Data = result.Data?.Data,
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}