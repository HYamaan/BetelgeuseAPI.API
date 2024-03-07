
using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Admin.AllUserSkills.AddUserSkills
{
    public class AddUserSkillCommandHandler :IRequestHandler<AddUserSkillCommandRequest, AddUserSkillCommandResponse>
    {
        private readonly IAdminService _adminService;

        public AddUserSkillCommandHandler(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<AddUserSkillCommandResponse> Handle(AddUserSkillCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _adminService.AddUserSkill(request);

            return new AddUserSkillCommandResponse()
            {
                Message = response.Message,
                Succeeded = response.Succeeded
            };
        }
    }
}
