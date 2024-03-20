using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.UserSettings.Experience.DeleteAccountExperience;

public class DeleteAccountExperiencesCommandHandler:IRequestHandler<DeleteAccountExperiencesCommandRequest,DeleteAccountExperiencesCommandResponse>
{
    private readonly IUserService _userService;

    public DeleteAccountExperiencesCommandHandler(IUserService userService)
    {
        _userService = userService;
    }


    public async Task<DeleteAccountExperiencesCommandResponse> Handle(DeleteAccountExperiencesCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.DeleteAccountExperience(request);
        return new DeleteAccountExperiencesCommandResponse()
        {
            Succeeded = response.Succeeded,
            Message = response.Message
        };
    }
}