using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.DTOs;
using BetelgeuseAPI.Application.DTOs.Request.Account;
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;

using BetelgeuseAPI.Domain.Settings;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BetelgeuseAPI.Persistence.Services
{
    public class AuthService:IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMailService _mailService;
        public readonly GoogleAuthSettings _googleAuthSettings;

        public AuthService(UserManager<AppUser> userManager, IMailService mailService, IOptions<GoogleAuthSettings> googleAuth)
        {
            _userManager = userManager;
            _mailService = mailService;
            _googleAuthSettings= googleAuth.Value;
        }
        public async Task<Response<Token>> GoogleLoginAsync(string idToken, int accessTokenLifeTime)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { _googleAuthSettings.GoogleId }
            };
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);

            var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");
            AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            //return await CreateUserExternalAsync(user, payload.Email, payload.Name, info, accessTokenLifeTime);
            return new Response<Token>();
        }

        public async Task ForgotPassword(ForgetPasswordRequest model, string origin)
        {
            var account = await _userManager.FindByEmailAsync(model.Email);
            // always return ok response to prevent email enumeration
            if (account == null) return;
            var token = await _userManager.GeneratePasswordResetTokenAsync(account);
            var route = "api/account/reset-password";
            var _enpointUri = new Uri(string.Concat($"{origin}/", route)).ToString();
            await _mailService.SendPasswordResetMailAsync(model.Email, account.Id, token, _enpointUri);
        }

    }
}
