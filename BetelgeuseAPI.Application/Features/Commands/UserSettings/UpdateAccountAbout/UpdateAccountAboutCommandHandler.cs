using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.UserSettings.UpdateAccountAbout;

public class UpdateAccountAboutCommandHandler:IRequestHandler<UpdateAccountAboutCommandRequest,UpdateAccountAboutCommandResponse>
{
    private readonly IUserService _userService;

    public UpdateAccountAboutCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<UpdateAccountAboutCommandResponse> Handle(UpdateAccountAboutCommandRequest request, CancellationToken cancellationToken)
    {
       var response= await _userService.UpdateAccountAbout(request);
       return new UpdateAccountAboutCommandResponse()
       {
           Succeeded = response.Succeeded,
           Message = response.Message
       };
    }
}