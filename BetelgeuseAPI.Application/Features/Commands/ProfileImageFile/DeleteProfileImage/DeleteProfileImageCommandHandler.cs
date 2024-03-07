using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.DeleteProfileImage;

public class DeleteProfileImageCommandHandler : IRequestHandler<DeleteProfileImageCommandRequest, DeleteProfileImageCommandResponse>
{
    private readonly IUserService _userService;

    public DeleteProfileImageCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<DeleteProfileImageCommandResponse> Handle(DeleteProfileImageCommandRequest request, CancellationToken cancellationToken)
    {
       var response = await _userService.DeleteAccountProfileImage();
       return new DeleteProfileImageCommandResponse()
       {
           Succeeded = response.Succeeded,
           Message = response.Message
       };
    }
}