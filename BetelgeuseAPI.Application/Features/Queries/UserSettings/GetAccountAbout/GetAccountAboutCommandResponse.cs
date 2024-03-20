
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountAbout;

public class GetAccountAboutCommandResponse:ResponseMessageAndSucceeded
{
    public string Biography { get; set; }
    public string JobTitle { get; set; }
}