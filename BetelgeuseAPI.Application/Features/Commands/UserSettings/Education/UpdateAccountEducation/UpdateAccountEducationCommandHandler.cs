using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.UserSettings.Education.UpdateAccountEducation;

public class UpdateAccountEducationCommandHandler:IRequestHandler<UpdateAccountEducationCommandRequest,UpdateAccountEducationCommandResponse>
{
    private readonly IUserService _userService;

    public UpdateAccountEducationCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<UpdateAccountEducationCommandResponse> Handle(UpdateAccountEducationCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.UpdateAccountEducation(request);

        return new UpdateAccountEducationCommandResponse()
        {
            Message = response.Message,
            Succeeded = response.Succeeded
        };
    }
}