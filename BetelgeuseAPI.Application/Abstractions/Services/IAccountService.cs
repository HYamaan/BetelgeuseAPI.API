using BetelgeuseAPI.Application.DTOs.Request.Account;
using BetelgeuseAPI.Application.DTOs.Response.Account;
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Abstractions.Services
{
    public interface IAccountService
    {
        Task<Response<CreateAccountResponse>> CreateAccountAsync(CreateAccountRequest request);
        Task<Response<LoginAccountResponse>> LoginAccountAsync(LoginAccountRequest request);
        Task<Response<string>> UpdatePasswordAsync(ResetPasswordRequest model);
        Task<Response<string>> ChangePassword(ChangePasswordRequest request);
    }
}
