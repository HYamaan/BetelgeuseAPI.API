using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.UserSettings.Education.DeleteAccountEducation;

public class DeleteAccountEducationCommandRequest:IRequest<DeleteAccountEducationCommandResponse>
{
    public string Id { get; set; }
}