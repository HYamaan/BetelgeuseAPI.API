using BetelgeuseAPI.Application.Features.Commands.Admin.AllUserSkills.AddUserSkills;
using BetelgeuseAPI.Application.Features.Commands.Admin.AllUserSkills.DeleteUserSkills;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Abstractions.Services;

public interface IAdminService
{
    Task<Response<AddUserSkillCommandResponse>> AddUserSkill(AddUserSkillCommandRequest request);

    Task<Response<DeleteUserSkillCommandResponse>> DeleteUserSkill(DeleteUserSkillCommandRequest request);
}