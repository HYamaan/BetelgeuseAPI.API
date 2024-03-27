using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Domain.Common;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.DeleteComponyLogo;

public class DeleteCompanyLogoCommandHandler:IRequestHandler<DeleteCompanyLogoCommandRequest, DeleteCompanyLogoCommandResponse>
{
    private readonly ICourseService _courseService;

    public DeleteCompanyLogoCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<DeleteCompanyLogoCommandResponse> Handle(DeleteCompanyLogoCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _courseService.DeleteCompanyLogo(request);
        return new DeleteCompanyLogoCommandResponse()
        {
            Message = response.Message,
            Succeeded = response.Succeeded
        };
    }
}