using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommandHandler:IRequestHandler<RevokeRefreshTokenCommandRequest, RevokeRefreshTokenCommandResponse>
    {
        private readonly IAccountService _accountService;

        public RevokeRefreshTokenCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<RevokeRefreshTokenCommandResponse> Handle(RevokeRefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _accountService.RevokeRefreshToken(request);

            return new  RevokeRefreshTokenCommandResponse()
            {
                Succeeded = response.Succeeded,
                Message = response.Message
            };
        }
    }
}
