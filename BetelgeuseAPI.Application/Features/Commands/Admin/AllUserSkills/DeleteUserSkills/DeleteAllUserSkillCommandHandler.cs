using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Admin.AllUserSkills.DeleteUserSkills;

public class DeleteAllUserSkillCommandHandler:IRequestHandler<DeleteAllUserSkillCommandRequest,DeleteAllUserSkillCommandResponse>
{
    private readonly IAdminService _adminService;

    public DeleteAllUserSkillCommandHandler(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public async Task<DeleteAllUserSkillCommandResponse> Handle(DeleteAllUserSkillCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _adminService.DeleteUserSkill(request);
        return new DeleteAllUserSkillCommandResponse()
        {
            Succeeded = response.Succeeded,
            Message = response.Message
        };
        
    }
}