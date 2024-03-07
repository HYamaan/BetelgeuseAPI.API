using MediatR;
using System.ComponentModel;

namespace BetelgeuseAPI.Application.Features.Commands.Admin.AllUserSkills.AddUserSkills;

public class AddUserSkillCommandRequest:IRequest<AddUserSkillCommandResponse>
{
    public string Skill { get; set; }

    public bool isCheck { get; set; } 
}