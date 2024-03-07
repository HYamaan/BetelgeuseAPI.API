using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Admin.AllUserSkills.DeleteUserSkills;

public class DeleteUserSkillCommandRequest:IRequest<DeleteUserSkillCommandResponse>
{
    public required string Id { get; set; }
}