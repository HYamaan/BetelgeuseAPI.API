using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.UserSettings.UpdateAccountAbout;

public class UpdateAccountAboutCommandRequest:IRequest<UpdateAccountAboutCommandResponse>
{
    public string Biography { get; set; }
    public string JobTitle { get; set; }
}