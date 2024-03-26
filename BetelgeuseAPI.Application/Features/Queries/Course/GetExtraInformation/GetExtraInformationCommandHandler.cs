using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetExtraInformation;

public class GetExtraInformationCommandHandler:IRequestHandler<GetExtraInformationCommandRequest,GetExtraInformationCommandResponse>
{
    private readonly ICourseService _courseService;

    public GetExtraInformationCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<GetExtraInformationCommandResponse> Handle(GetExtraInformationCommandRequest request, CancellationToken cancellationToken)
    {
       var result = await _courseService.GetExtraInformation(request);

       return new GetExtraInformationCommandResponse()
       {
           Data = result.Data?.Data,
           Message = result.Message,
           Succeeded = result.Succeeded
       };
    }
}