using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.UserSettings.Experience.UpdateAccountExperience;

public class UpdateAccountExperiencesCommandRequest:IRequest<UpdateAccountExperiencesCommandResponse>
{
    public string Id { get; set; }
    public string Experience { get; set; }
}