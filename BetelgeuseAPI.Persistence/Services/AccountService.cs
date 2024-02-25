using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Abstractions.Token;
using BetelgeuseAPI.Application.DTOs.Request.Account;
using BetelgeuseAPI.Application.DTOs.Response.Account;
using BetelgeuseAPI.Application.Exceptions;
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Enum;
using BetelgeuseAPI.Domain.Settings;
using Microsoft.AspNetCore.Identity;

namespace BetelgeuseAPI.Persistence.Services
{
    public class AccountService:IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IMailService _mailService;

        public AccountService(UserManager<AppUser> userManager, IMapper mapper, ITokenHandler tokenHandler, SignInManager<AppUser> signInManager, IMailService mailService)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
            _mailService = mailService;
        }

        public async Task<Response<CreateAccountResponse>> CreateAccountAsync(CreateAccountRequest request)
        {
            try
            {
                var userWithSameEmailAsync = await _userManager.FindByEmailAsync(request.Email);
                if (userWithSameEmailAsync != null)
                {
                    UserCreateFailedException userCreateFailedException = new("Bu e-posta adresi ile kayıtlı bir kullanıcı bulunmaktadır.");
                    throw userCreateFailedException;
                }
                var user = new AppUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = request.Email,
                    UserName = request.Email
                };
                var result = await _userManager.CreateAsync(user, request.Password);
                var createUserResponse = new Response<CreateAccountResponse>();

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.Student.ToString());
                    //TODO: Send Email

                    createUserResponse.Succeeded = true;
                    createUserResponse.Message = "Kullanıcı başarıyla oluşturuldu.";
                }
                else
                {
                    createUserResponse.Succeeded = false;
                    foreach (IdentityError error in result.Errors)
                    {
                        createUserResponse.Message += $"{error.Code} - {error.Description}\n";
                    }
                }

                return createUserResponse;

            }
            catch (Exception e)
            {
                return new Response<CreateAccountResponse>() { Succeeded = false, Message = e.Message };
            }
        }

        public async Task<Response<LoginAccountResponse>> LoginAccountAsync(LoginAccountRequest request)
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

                JwtSecurityToken jwtSecurityToken = await _tokenHandler.GenerateJWToken(user);

                LoginAccountResponse response = new LoginAccountResponse();
                response.Id = user.Id;
                response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                response.Email = user.Email!;
                var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                response.Roles = rolesList.ToList();
                response.IsVerified = user.EmailConfirmed;

                var refreshToken = _tokenHandler.GenerateRefreshToken(request.IPAddress!);
                response.RefreshToken = refreshToken.Token;


                return new Response<LoginAccountResponse>(response, $"Authenticated {user.UserName}");
            }
            catch (Exception e)
            {
                return new Response<LoginAccountResponse>() { Succeeded = false, Message = e.Message };
            }
        }

        public async Task<Response<string>> UpdatePasswordAsync(ResetPasswordRequest model)
        {
            try
            {
                AppUser account = await _userManager.FindByIdAsync(model.Id);
                if (account == null) throw new ApiException($"No Accounts Registered with {account.Email}.");
                IdentityResult result = await _userManager.ResetPasswordAsync(account, model.Token, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(account);
                    return new Response<string>(account.Email, message: $"Password Resetted.");
                }
                else
                {
                    throw new ApiException($"Error occured while reseting the password.");
                }

            }
            catch (Exception e)
            {
                return new Response<string>() { Succeeded = false, Message = e.Message };
            }
        }

        public async Task<Response<string>> ChangePassword(ChangePasswordRequest model)
        {
            try
            {
                var account = await _userManager.FindByEmailAsync(model.Email!);
                if(account == null) throw new ApiException($"No Accounts Registered with {model.Email}.");
                if (model.NewPassword != model.ConfirmNewPassword)
                {
                    throw new ApiException("The new password and confirm new password do not match!");
                }

                var result = await _userManager.ChangePasswordAsync(account, model.CurrentPassword!, model.NewPassword!);
             
                if (!result.Succeeded)
                {
                    var response = new Response<string>();
                    foreach (var error in result.Errors)
                        response.Message += $"{error.Code} - {error.Description}\n";

                    response.Succeeded = false;
                    return response;
                }

                return new Response<string>()
                    { Succeeded = true, Message = "Password Change Successfully!" };
            }
            catch (Exception e)
            {
                return new Response<string>() { Succeeded = false, Message = e.Message };
            }
        }
    }
}
