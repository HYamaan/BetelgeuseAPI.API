using BetelgeuseAPI.Application.DTOs.Response.Account;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountEducation;

public class GetAccountEducationCommandResponse:ResponseMessageAndSucceeded
{
    public List<AccountEducationDto> Education { get; set; }
}