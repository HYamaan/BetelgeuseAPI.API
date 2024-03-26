
using BetelgeuseAPI.Application.DTOs.Response.Account;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.CreateTokenByRefreshToken
{
    public class RefreshTokenLoginCommandResponse : ResponseMessageAndSucceeded
    {
        public LoginResponseDto Data { get; set; }
    }
}
