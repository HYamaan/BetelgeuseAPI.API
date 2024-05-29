using BetelgeuseAPI.Application.Features.Commands.Admin.AllUserSkills.AddUserSkills;
using BetelgeuseAPI.Application.Features.Commands.Admin.AllUserSkills.DeleteUserSkills;
using BetelgeuseAPI.Application.Features.Commands.Admin.Course.CourseControl;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Abstractions.Services;

public interface IAdminService
{
    Task<Response<AddAllUserSkillCommandResponse>> AddUserSkill(AddAllUserSkillCommandRequest request);
    Task<Response<CoursePublishedCommandResponse>> CoursePublished(CoursePublishedCommandRequest request);

    Task<Response<DeleteAllUserSkillCommandResponse>> DeleteUserSkill(DeleteAllUserSkillCommandRequest request);
}