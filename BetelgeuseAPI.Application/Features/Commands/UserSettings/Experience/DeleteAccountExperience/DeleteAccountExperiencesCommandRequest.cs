using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.UserSettings.Experience.DeleteAccountExperience;

public class DeleteAccountExperiencesCommandRequest:IRequest<DeleteAccountExperiencesCommandResponse>
{
    public string Id { get; set; }
}