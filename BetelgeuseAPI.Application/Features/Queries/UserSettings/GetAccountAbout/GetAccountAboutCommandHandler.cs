using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountAbout;

public class GetAccountAboutCommandHandler:IRequestHandler<GetAccountAboutCommandRequest,GetAccountAboutCommandResponse>
{
    private readonly IUserService _userService;

    public GetAccountAboutCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetAccountAboutCommandResponse> Handle(GetAccountAboutCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.GetAccountAbout(request);
        if(response == null )  return new GetAccountAboutCommandResponse();
        return new GetAccountAboutCommandResponse()
        {
            Biography = response.Data.Biography,
            JobTitle = response.Data.JobTitle,
            Succeeded = response.Succeeded,
            Message = response.Message
        };
    }
}