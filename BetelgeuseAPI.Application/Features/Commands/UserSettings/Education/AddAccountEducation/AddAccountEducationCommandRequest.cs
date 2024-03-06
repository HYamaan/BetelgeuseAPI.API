using BetelgeuseAPI.Application.Features.Commands.UserSettings.AddAccountExperiences;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.UserSettings.AddAccountEducation;

public class AddAccountEducationCommandRequest:IRequest<AddAccountEducationCommandResponse>
{
    public string Education { get; set; }
}