using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.UserSettings.AddAccountExperiences;

public class AddAccountExperiencesCommandRequest:IRequest<AddAccountExperiencesCommandResponse>
{
    public string? Experiences { get; set; }
}