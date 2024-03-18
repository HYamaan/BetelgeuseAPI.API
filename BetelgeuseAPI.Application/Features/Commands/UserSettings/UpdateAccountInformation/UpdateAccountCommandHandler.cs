using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.UserSettings.UploadAccountInformation
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommandRequest, UpdateAccountCommandResponse>
    {
        private readonly IUserService _userService;

        public UpdateAccountCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UpdateAccountCommandResponse> Handle(UpdateAccountCommandRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _userService.UpdateAccountInformation(request);
            return new UpdateAccountCommandResponse()
            {
                Message = response.Message,
                Succeeded = response.Succeeded
            };
        }
    }
}