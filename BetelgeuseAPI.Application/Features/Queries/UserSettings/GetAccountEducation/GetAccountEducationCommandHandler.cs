using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountEducation;

public class GetAccountEducationCommandHandler:IRequestHandler<GetAccountEducationCommandRequest,GetAccountEducationCommandResponse>
{
    private readonly IUserService _userService;

    public GetAccountEducationCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetAccountEducationCommandResponse> Handle(GetAccountEducationCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.GetAccountEducation(request);

        return new GetAccountEducationCommandResponse()
        {
            Education = response.Data,
            Succeeded = response.Succeeded,
            Message = response.Message
        };
    }
}