using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        private readonly IAuthService _authService;

        public GoogleLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.GoogleLoginAsync(request.IdToken,request.IpAddress);

            return new GoogleLoginCommandResponse();
        }
    }
}
