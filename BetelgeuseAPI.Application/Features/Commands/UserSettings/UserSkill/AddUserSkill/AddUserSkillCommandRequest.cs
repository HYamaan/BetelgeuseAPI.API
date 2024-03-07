using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.UserSettings.UserSkill.AddUserSkill;

public class AddUserSkillCommandRequest:IRequest<AddUserSkillCommandResponse>
{
    public string Skill { get; set; }
    public bool isCheck { get; set; }
}