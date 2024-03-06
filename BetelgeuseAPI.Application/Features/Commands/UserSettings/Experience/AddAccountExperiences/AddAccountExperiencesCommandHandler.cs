using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.UserSettings.AddAccountExperiences;

public class AddAccountExperiencesCommandHandler:IRequestHandler<AddAccountExperiencesCommandRequest,AddAccountExperiencesCommandResponse>
{
    private readonly IUserService _userService;

    public AddAccountExperiencesCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<AddAccountExperiencesCommandResponse> Handle(AddAccountExperiencesCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.AddAccountExperiences(request);

        return new AddAccountExperiencesCommandResponse()
        {
            Succeeded = response.Succeeded,
            Message = response.Message
        };
    }
}