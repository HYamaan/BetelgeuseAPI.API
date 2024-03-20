using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.DeleteProfileBackgroundImage;

public class DeleteProfileImageCommandHandler : IRequestHandler<DeleteProfileBackgroundImageCommandRequest, DeleteProfileBackgroundPhotoCommandResponse>
{
    private readonly IUserService _userService;

    public DeleteProfileImageCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<DeleteProfileBackgroundPhotoCommandResponse> Handle(DeleteProfileBackgroundImageCommandRequest request, CancellationToken cancellationToken)
    {
       var response = await _userService.DeleteAccountProfileBackgroundImage();
       return new DeleteProfileBackgroundPhotoCommandResponse()
       {
           Succeeded = response.Succeeded,
           Message = response.Message
       };
    }
}