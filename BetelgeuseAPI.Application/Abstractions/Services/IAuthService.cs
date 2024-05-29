using BetelgeuseAPI.Application.Abstractions.Services.Authentications;
using BetelgeuseAPI.Application.DTOs.Request.Account;
using BetelgeuseAPI.Application.Features.Commands.AppUser.ForgetPassword;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Abstractions.Services
{
    public interface IAuthService:IExternalAuthentication,IInternalAuthentication
    {
        Task<Response<ForgetPasswordCommandResponse>> ForgotPassword(ForgetPasswordRequest forgetPasswordRequest, string origin);
    }
}
