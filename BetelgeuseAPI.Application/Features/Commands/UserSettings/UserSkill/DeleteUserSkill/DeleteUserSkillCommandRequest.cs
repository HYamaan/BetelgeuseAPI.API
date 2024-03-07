using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.UserSettings.UserSkill.DeleteUserSkill;

public class DeleteUserSkillCommandRequest:IRequest<DeleteUserSkillCommandResponse>
{
    public string Id { get; set; }
}