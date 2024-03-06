using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.UserSettings.AddAccountEducation;

public class AddAccountEducationCommandHandler:IRequestHandler<AddAccountEducationCommandRequest,AddAccountEducationCommandResponse>
{
    private readonly IUserService _userService;

    public AddAccountEducationCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<AddAccountEducationCommandResponse> Handle(AddAccountEducationCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.AddAccountEducation(request);
        return new AddAccountEducationCommandResponse()
        {
            Succeeded = response.Succeeded,
            Message = response.Message
        };
    }
}