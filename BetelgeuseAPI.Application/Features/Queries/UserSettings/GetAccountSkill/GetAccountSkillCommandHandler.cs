using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountSkill;

public class GetAccountSkillCommandHandler:IRequestHandler<GetAccountSkillCommandRequest,GetAccountSkillCommandResponse>
{
    private readonly IUserService _userService;

    public GetAccountSkillCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetAccountSkillCommandResponse> Handle(GetAccountSkillCommandRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _userService.GetUserSkills();
        var skills = response.Data;

        return new GetAccountSkillCommandResponse()
        {
            Skills = skills,
            Succeeded = response.Succeeded,
            Message = response.Message
        };
    }
}