
using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Admin.AllUserSkills.AddUserSkills
{
    public class AddAllUserSkillCommandHandler :IRequestHandler<AddAllUserSkillCommandRequest, AddAllUserSkillCommandResponse>
    {
        private readonly IAdminService _adminService;

        public AddAllUserSkillCommandHandler(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<AddAllUserSkillCommandResponse> Handle(AddAllUserSkillCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _adminService.AddUserSkill(request);

            return new AddAllUserSkillCommandResponse()
            {
                Message = response.Message,
                Succeeded = response.Succeeded
            };
        }
    }
}
