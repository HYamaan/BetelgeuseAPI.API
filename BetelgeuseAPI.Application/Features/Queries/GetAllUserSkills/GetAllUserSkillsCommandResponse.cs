using BetelgeuseAPI.Application.DTOs.Response.Account;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.GetAllUserSkills
{
    public class GetAllUserSkillsCommandResponse:ResponseMessageAndSucceeded
    {
        public List<AccountUserSkillsDto> Data { get; set; }
    }
}
