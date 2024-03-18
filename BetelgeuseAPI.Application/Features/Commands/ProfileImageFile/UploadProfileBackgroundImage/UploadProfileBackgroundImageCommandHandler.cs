

using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.UploadProfileBackgroundImage
{
    public class UploadProfileBackgroundImageCommandHandler : IRequestHandler<UploadProfileBackgroundImageCommandRequest, UploadProfileBackgroundImageCommandResponse>
    {
        private readonly IUserService _userService;

        public UploadProfileBackgroundImageCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UploadProfileBackgroundImageCommandResponse> Handle(UploadProfileBackgroundImageCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.profileBackgroundImage == null)
                    return new UploadProfileBackgroundImageCommandResponse();

            var response = await _userService.AddProfileBackgroundPhoto(request);
            return new UploadProfileBackgroundImageCommandResponse()
            {
                Succeeded = response.Succeeded,
                Message = response.Message
            };
        }
    }
}
