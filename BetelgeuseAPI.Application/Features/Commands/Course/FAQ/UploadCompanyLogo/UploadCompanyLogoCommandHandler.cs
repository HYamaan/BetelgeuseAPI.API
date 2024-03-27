using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadCompanyLogo;

public class UploadCompanyLogoCommandHandler:IRequestHandler<UploadCompanyLogoCommandRequest, UploadCompanyLogoCommandResponse>
{
    private readonly ICourseService _courseService;

    public UploadCompanyLogoCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<UploadCompanyLogoCommandResponse> Handle(UploadCompanyLogoCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _courseService.UploadCompanyLogo(request);

        return new UploadCompanyLogoCommandResponse()
        {
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}