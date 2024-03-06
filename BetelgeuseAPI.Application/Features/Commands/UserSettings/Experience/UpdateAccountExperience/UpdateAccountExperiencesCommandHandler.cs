using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.UserSettings.Experience.UpdateAccountExperience;

public class UpdateAccountExperiencesCommandHandler:IRequestHandler<UpdateAccountExperiencesCommandRequest,UpdateAccountExperiencesCommandResponse>
{
    private readonly IUserService _userService;

    public UpdateAccountExperiencesCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<UpdateAccountExperiencesCommandResponse> Handle(UpdateAccountExperiencesCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.UpdateAccountExperience(request);
        return new UpdateAccountExperiencesCommandResponse()
        {
            Message = response.Message,
            Succeeded = response.Succeeded
        };
    }
}