using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.UserSettings.UserSkill.AddUserSkill;

public class AddUserSkillsCommandHandler:IRequestHandler<AddUserSkillCommandRequest,AddUserSkillCommandResponse>
{
    private readonly IUserService _userService;

    public AddUserSkillsCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<AddUserSkillCommandResponse> Handle(AddUserSkillCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.AddUserSkill(request);

        return new AddUserSkillCommandResponse()
        {
            Message = response.Message,
            Succeeded = response.Succeeded
        };
    }
}