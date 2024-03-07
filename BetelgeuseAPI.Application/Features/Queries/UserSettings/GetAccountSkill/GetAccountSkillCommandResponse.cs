using BetelgeuseAPI.Application.DTOs.Response.Account;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities;

namespace BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountSkill;

public class GetAccountSkillCommandResponse:ResponseMessageAndSucceeded
{
    public List<AccountUserSkillsDto> Skills { get; set; }
}