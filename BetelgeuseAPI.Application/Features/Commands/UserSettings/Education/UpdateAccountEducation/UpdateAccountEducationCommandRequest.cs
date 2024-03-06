using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.UserSettings.Education.UpdateAccountEducation;

public class UpdateAccountEducationCommandRequest:IRequest<UpdateAccountEducationCommandResponse>
{
    public string Id { get; set; }
    public string Education { get; set; }
}