using BetelgeuseAPI.Application.DTOs.Response.Account;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountExperiences;

public class GetAccountExperienceCommandResponse:ResponseMessageAndSucceeded
{
    public List<AccountExperienceDto> Experience { get; set; }
}