using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountExperiences;

public class GetAccountExperienceCommandHandler:IRequestHandler<GetAccountExperienceCommandRequest,GetAccountExperienceCommandResponse>
{
    private readonly IUserService _userService;

    public GetAccountExperienceCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetAccountExperienceCommandResponse> Handle(GetAccountExperienceCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.GetAccountExperiences(request);
        return new GetAccountExperienceCommandResponse()
        {
            Experience = response.Data,
            Succeeded = response.Succeeded,
            Message = response.Message
        };
    }
}