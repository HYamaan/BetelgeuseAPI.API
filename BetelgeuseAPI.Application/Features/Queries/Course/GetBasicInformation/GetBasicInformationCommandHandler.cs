using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetBasicInformation;

public class GetBasicInformationCommandHandler:IRequestHandler<GetBasicInformationCommandRequest, GetBasicInformationCommandResponse>
{
    private readonly ICourseService _courseService;

    public GetBasicInformationCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<GetBasicInformationCommandResponse> Handle(GetBasicInformationCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _courseService.GetCourseBasicInformation(request);

        return new GetBasicInformationCommandResponse()
        {
            Data = result.Data?.Data,
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}