

using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.ProfileImageFile.GetProfileImage;

public class GetProfileImageCommandHandler : IRequestHandler<GetProfileImageCommandRequest, GetProfileImageCommandResponse>
{

    private readonly IUserService _userService;

    public GetProfileImageCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetProfileImageCommandResponse> Handle(GetProfileImageCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.GetAccountProfileImage();
        return new GetProfileImageCommandResponse()
        {
            GuidId = response.Data.GuidId,
            FileName = response.Data.FileName,
            Path = response.Data.Path,
            Succeeded = response.Succeeded,
            Message = response.Message
        };
    }
}