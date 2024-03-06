using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommandRequest:IRequest<RevokeRefreshTokenCommandResponse>
    {
        public string RefreshToken { get; set; }
    }
}
