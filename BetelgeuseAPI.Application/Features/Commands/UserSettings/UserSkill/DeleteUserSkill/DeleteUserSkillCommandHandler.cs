using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.UserSettings.UserSkill.DeleteUserSkill;

//public class DeleteUserSkillCommandHandler:IRequestHandler<DeleteUserSkillCommandRequest,DeleteUserSkillCommandResponse>
//{
//    private readonly IAdminService _adminService;

//    public DeleteUserSkillCommandHandler(IAdminService adminService)
//    {
//        _adminService = adminService;
//    }

//    public async Task<DeleteUserSkillCommandResponse> Handle(DeleteUserSkillCommandRequest request, CancellationToken cancellationToken)
//    {
//        var response = await _adminService.DeleteUserSkill(request);
//        return new DeleteUserSkillCommandResponse()
//        {
//            Succeeded = response.Succeeded,
//            Message = response.Message
//        };
        
//    }
//}