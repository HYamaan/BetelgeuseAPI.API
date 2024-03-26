using BetelgeuseAPI.Application.DTOs;
using BetelgeuseAPI.Application.DTOs.Request.Account;
using BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.CreateTokenByRefreshToken;
using BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.LoginUser;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Abstractions.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<Response<LoginUserCommandResponse>> LoginAccountAsync(LoginAccountRequest request);
        Task<Response<RefreshTokenLoginCommandResponse>> RefreshTokenLoginAsync(RefreshTokenLoginCommandRequest request);
    }
}
