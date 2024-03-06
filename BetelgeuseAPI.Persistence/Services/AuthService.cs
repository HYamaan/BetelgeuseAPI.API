using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Abstractions.Token;
using BetelgeuseAPI.Application.DTOs;
using BetelgeuseAPI.Application.DTOs.Request.Account;
using BetelgeuseAPI.Application.Exceptions;
using BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.CreateTokenByRefreshToken;
using BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.LoginUser;
using BetelgeuseAPI.Application.Repositories;
using BetelgeuseAPI.Application.Repositories.UserRefreshToken;
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;

using BetelgeuseAPI.Domain.Settings;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Ocsp;

namespace BetelgeuseAPI.Persistence.Services
{
    public class AuthService:IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUnitOfWork _unitOfWork;
        public readonly IUserRefreshTokenReadRepository _refreshTokenReadRepository;
        private readonly IMailService _mailService;
        public readonly GoogleAuthSettings _googleAuthSettings;

        public AuthService(UserManager<AppUser> userManager, IMailService mailService, IOptions<GoogleAuthSettings> googleAuth, IUserRefreshTokenReadRepository refreshTokenReadRepository, ITokenHandler tokenHandler, SignInManager<AppUser> signInManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mailService = mailService;
            _refreshTokenReadRepository = refreshTokenReadRepository;
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _googleAuthSettings= googleAuth.Value;
        }
        private async Task<Response<TokenDto>> CreateUserExternalAsync(AppUser user, string email, UserLoginInfo info,string IPAddress )
        {
            bool result = user != null;
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = email,
                        UserName = email,
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
                }
            }

            if (result)
            {
                await _userManager.AddLoginAsync(user, info); //AspNetUserLogins

                TokenDto token =await _tokenHandler.GenerateJWToken(user);
                await UpdateRefreshTokenAsync(token, user, IPAddress);

                return  Response<TokenDto>.Success(token);
            }
            return new Response<TokenDto>(){ Succeeded = false, Message = "Invalid external authentication." };
        }
        public async Task<Response<TokenDto>> GoogleLoginAsync(string idToken,string IpAddress)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { _googleAuthSettings.GoogleId }
            };
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);

            var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");
            AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            return await CreateUserExternalAsync(user, payload.Email, info, IpAddress);
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

        public async Task<Response<LoginUserCommandResponse>> LoginAccountAsync(LoginAccountRequest request)
        {
            try
            {
                AppUser user = await _userManager.FindByEmailAsync(request.Email);

                if (user == null)
                    throw new ApiException($"No Accounts Registered with {request.Email}.");

                SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                if (!signInResult.Succeeded)
                {
                    throw new ApiException($"Invalid Credentials for '{request.Email}'.");
                }

                TokenDto token = await _tokenHandler.GenerateJWToken(user);
                await UpdateRefreshTokenAsync(token, user, request.IPAddress);


                 var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                LoginUserCommandResponse response = new LoginUserCommandResponse();
                response.Id= user.Id;
                response.AccessToken = token.AccessToken;
                response.Email = user.Email!;
                response.Roles = rolesList.ToList();
                response.IsVerified = user.EmailConfirmed;
                response.RefreshToken = token.RefreshToken;
                response.Succeeded = true;
                response.Message = $"Authenticated {user.UserName}";
                

                return  Response<LoginUserCommandResponse>.Success(response);
            }
            catch (Exception e)
            {
                return new Response<LoginUserCommandResponse>() { Succeeded = false, Message = e.Message };
            }

        }

        private async Task UpdateRefreshTokenAsync(TokenDto token,AppUser user,string IPAddress)
        {
            var userRefreshToken = await _refreshTokenReadRepository
                .GetWhere(x => x.AppUserId == user.Id && x.CreatedByIp == IPAddress).ToListAsync();
            var expiredToken = userRefreshToken.FirstOrDefault(x => !x.IsExpired);


            if (expiredToken is not null)
            {
                expiredToken.Expires = token.RefreshTokenExpiration.ToUniversalTime();
                expiredToken.Token = token.RefreshToken;
            }
            else
            {
                user.RefreshTokens = new List<RefreshToken>();

                user.RefreshTokens.Add(new RefreshToken()
                {
                    Token = token.RefreshToken,
                    Expires = token.RefreshTokenExpiration.ToUniversalTime(),
                    CreatedDate = DateTime.UtcNow,
                    CreatedByIp = IPAddress
                });
            }
            await _unitOfWork.CommitIdentityAsync();
        }

        public async Task<Response<TokenDto>> RefreshTokenLoginAsync(RefreshTokenLoginCommandRequest request)
        {
            var existRefreshToken = _refreshTokenReadRepository.GetWhere(x => x.Token == request.RefreshToken && x.CreatedByIp == request.IPAddress).SingleOrDefault();
            if (existRefreshToken == null)
            {
                return new Response<TokenDto>() { Succeeded = false, Message = "Invalid Refresh Token" };
            }
            var user = await _userManager.FindByIdAsync(existRefreshToken.AppUserId!);

            if (user == null)
            {
                return new Response<TokenDto>() { Succeeded = false, Message = "User Not Found" };
            }
            var tokenDto = await _tokenHandler.GenerateJWToken(user);
            existRefreshToken.Token = tokenDto.RefreshToken;
            existRefreshToken.Expires = tokenDto.RefreshTokenExpiration.ToUniversalTime();
            await _unitOfWork.CommitIdentityAsync();
            return new Response<TokenDto>() { Data = tokenDto, Succeeded = true, Message = "Created refresh token" };
        }

    }
}
