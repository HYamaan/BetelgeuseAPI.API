using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.UserSettings.Education.DeleteAccountEducation;

public class DeleteAccountEducationCommandHandler:IRequestHandler<DeleteAccountEducationCommandRequest,DeleteAccountEducationCommandResponse>
{

    private readonly IUserService _userService;

    public DeleteAccountEducationCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<DeleteAccountEducationCommandResponse> Handle(DeleteAccountEducationCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.DeleteAccountEducation(request);
        return new DeleteAccountEducationCommandResponse()
        {
            Message = response.Message,
            Succeeded = response.Succeeded
        };
    }
}