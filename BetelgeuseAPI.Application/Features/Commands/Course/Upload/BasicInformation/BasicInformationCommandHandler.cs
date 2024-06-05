using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Upload.BasicInformation;

public class BasicInformationCommandHandler : IRequestHandler<BasicInformationCommandRequest, BasicInformationCommandResponse>
{
    private readonly ICourseService _courseService;

    public BasicInformationCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<BasicInformationCommandResponse> Handle(BasicInformationCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _courseService.AddCourseBasicInformation(request);

        return new BasicInformationCommandResponse()
        {
            Data = result.Data?.Data,
            Succeeded = result.Succeeded,
            Message = result.Message
        };
    }
}