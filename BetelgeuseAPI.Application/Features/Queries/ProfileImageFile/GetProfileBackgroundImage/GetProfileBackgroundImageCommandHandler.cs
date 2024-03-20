

using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.ProfileImageFile.GetProfileBackgroundImage;

public class GetProfileImageCommandHandler : IRequestHandler<GetProfileBackgroundImageCommandRequest, GetProfileBackgroundImageCommandResponse>
{

    private readonly IUserService _userService;

    public GetProfileImageCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetProfileBackgroundImageCommandResponse> Handle(GetProfileBackgroundImageCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.GetAccountProfileBackgroundImage();
        return new GetProfileBackgroundImageCommandResponse()
        {
            GuidId = response.Data.GuidId,
            FileName = response.Data.FileName,
            Path = response.Data.Path,
            Succeeded = response.Succeeded,
            Message = response.Message
        };
    }
}