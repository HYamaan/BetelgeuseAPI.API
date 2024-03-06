using BetelgeuseAPI.Application.DTOs;
using BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.RevokeRefreshToken;
using BetelgeuseAPI.Application.Features.Commands.AppUser.ChangePassword;
using BetelgeuseAPI.Application.Features.Commands.AppUser.CreateUser;
using BetelgeuseAPI.Application.Features.Commands.AppUser.UpdatePassword;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Abstractions.Services
{
    public interface IAccountService
    {
        Task<Response<CreateUserCommandResponse>> CreateAccountAsync(CreateUserCommandRequest request);
        Task<Response<string>> UpdatePasswordAsync(UpdatePasswordCommandRequest model);
        Task<Response<string>> ChangePassword(ChangePasswordCommandRequest request);
        Task<Response<NoDataDto>> RevokeRefreshToken(RevokeRefreshTokenCommandRequest request);
    }
}
