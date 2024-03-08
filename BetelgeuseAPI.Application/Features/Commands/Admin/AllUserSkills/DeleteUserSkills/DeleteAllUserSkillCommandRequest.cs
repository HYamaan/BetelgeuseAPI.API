using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Admin.AllUserSkills.DeleteUserSkills;

public class DeleteAllUserSkillCommandRequest:IRequest<DeleteAllUserSkillCommandResponse>
{
    public required string Id { get; set; }
}