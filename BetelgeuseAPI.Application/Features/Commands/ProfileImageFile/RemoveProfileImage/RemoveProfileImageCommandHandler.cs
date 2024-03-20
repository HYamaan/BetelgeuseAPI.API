
using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.RemoveProfileImage;

public class RemoveProfileImageCommandHandler : IRequestHandler<RemoveProfileImageCommandRequest, RemoveProfilePhotoCommandResponse>
{
    private readonly IUserService _userService;

    public RemoveProfileImageCommandHandler(IUserService userService)
    {
        _userService = userService;
    }


    public async Task<RemoveProfilePhotoCommandResponse> Handle(RemoveProfileImageCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.DeleteAccountProfileImage();

        return new RemoveProfilePhotoCommandResponse()
        {
            Succeeded = response.Succeeded,
            Message = response.Message
        };
    }
}