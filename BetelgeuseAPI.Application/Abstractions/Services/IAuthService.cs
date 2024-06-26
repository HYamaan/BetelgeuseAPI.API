﻿using BetelgeuseAPI.Application.Abstractions.Services.Authentications;
using BetelgeuseAPI.Application.DTOs.Request.Account;

namespace BetelgeuseAPI.Application.Abstractions.Services
{
    public interface IAuthService:IExternalAuthentication,IInternalAuthentication
    {
        Task ForgotPassword(ForgetPasswordRequest forgetPasswordRequest, string origin);
    }
}
