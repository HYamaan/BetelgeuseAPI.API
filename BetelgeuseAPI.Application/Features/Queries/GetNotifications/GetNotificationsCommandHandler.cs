using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.GetNotifications;

public class GetNotificationsCommandHandler:IRequestHandler<GetNotificationsCommandRequest,GetNotificationsCommandResponse>
{
    private readonly IUserService _userService;

    public GetNotificationsCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetNotificationsCommandResponse> Handle(GetNotificationsCommandRequest request, CancellationToken cancellationToken)
    {
       var response = await _userService.GetNotifications();
       return new GetNotificationsCommandResponse()
       {
           Data = response.Data?.Data,
           Message = response.Message,
           Succeeded = response.Succeeded
       };
    }
}