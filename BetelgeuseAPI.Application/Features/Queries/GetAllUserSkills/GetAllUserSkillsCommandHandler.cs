

using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.GetAllUserSkills
{
    public class GetAllUserSkillsCommandHandler:IRequestHandler<GetAllUserSkillsCommandRequest,GetAllUserSkillsCommandResponse>
    {
        private readonly IUserService _userService;

        public GetAllUserSkillsCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetAllUserSkillsCommandResponse> Handle(GetAllUserSkillsCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _userService.GetAllUserSkills();

            return new GetAllUserSkillsCommandResponse()
            {
                Data = response.Data,
                Succeeded = response.Succeeded,
                Message = response.Message
            };
        }
    }
}
