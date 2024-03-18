using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;


namespace BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.UploadProfileImage
{
    public class UploadProfileImageCommandHandler : IRequestHandler<UploadProfileImageCommandRequest, UploadProfileImageCommandResponse>
    {
        private readonly IUserService _userService;

        public UploadProfileImageCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UploadProfileImageCommandResponse> Handle(UploadProfileImageCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.profileImage == null)
                    return new UploadProfileImageCommandResponse();

            var response = await _userService.AddProfilePhoto(request);
            return new UploadProfileImageCommandResponse()
            {
                Succeeded = response.Succeeded,
                Message = response.Message
            };
        }
    }
}
