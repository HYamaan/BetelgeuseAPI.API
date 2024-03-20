using System.Security.Claims;
using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.DTOs;
using BetelgeuseAPI.Application.Exceptions;
using BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.RevokeRefreshToken;
using BetelgeuseAPI.Application.Features.Commands.AppUser.ChangePassword;
using BetelgeuseAPI.Application.Features.Commands.AppUser.CreateUser;
using BetelgeuseAPI.Application.Features.Commands.AppUser.UpdatePassword;
using BetelgeuseAPI.Application.Repositories;
using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountAbout;
using BetelgeuseAPI.Application.Repositories.UserRefreshToken;
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BetelgeuseAPI.Persistence.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRefreshTokenWriteRepository _refreshTokenWriteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRefreshTokenReadRepository _refreshTokenReadRepository;
        
        private readonly IUserAccountAboutWriteRepository _aboutWriteRepository;
        private IHttpContextAccessor _httpContextAccessor;

        
        public AccountService(UserManager<AppUser> userManager, IUnitOfWork unitOfWork,
            IUserRefreshTokenReadRepository refreshTokenReadRepository,
            IUserRefreshTokenWriteRepository refreshTokenWriteRepository, 
            IHttpContextAccessor httpContextAccessor, IUserAccountAboutWriteRepository aboutWriteRepository)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _refreshTokenReadRepository = refreshTokenReadRepository;
            _refreshTokenWriteRepository = refreshTokenWriteRepository;
            _httpContextAccessor = httpContextAccessor;
            _aboutWriteRepository = aboutWriteRepository;
        }

        public async Task<Response<CreateUserCommandResponse>> CreateAccountAsync(CreateUserCommandRequest request)
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
                    UserName = request.Email.Split("@")[0]
                };
                var result = await _userManager.CreateAsync(user, request.Password);
                var createUserResponse = new Response<CreateUserCommandResponse>();

                if (result.Succeeded)
                {
                    AddAbout(user.Id);
                    await _userManager.AddToRoleAsync(user, Roles.Student.ToString());
                    await _unitOfWork.CommitIdentityAsync();
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
                return new Response<CreateUserCommandResponse>() { Succeeded = false, Message = e.Message };
            }
        }

        public async Task<Response<string>> UpdatePasswordAsync(UpdatePasswordCommandRequest model)
        {
            try
            {
                AppUser account = await _userManager.FindByIdAsync(model.Id);
                if (account == null) throw new ApiException($"No Accounts Registered with {account.Email}.");
                IdentityResult result = await _userManager.ResetPasswordAsync(account, model.Token, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(account);
                    return  Response<string>.Success(account.Email, message: $"Password Resetted.");
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
        public async Task<Response<string>> ChangePassword(ChangePasswordCommandRequest model)
        {
            try
            {
                var userEmail = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)
                    ?.Value;
                var account = await _userManager.FindByEmailAsync(userEmail);
                if (account == null) throw new ApiException($"No Accounts Registered with {userEmail}.");
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
        public async Task<Response<NoDataDto>> RevokeRefreshToken(RevokeRefreshTokenCommandRequest request)
        {
            var existRefreshToken = _refreshTokenReadRepository
                .GetWhere(x => x.Token == request.RefreshToken).SingleOrDefault();

            if (existRefreshToken == null)
            {
                return new Response<NoDataDto>() { Succeeded = false, Message = "Invalid Refresh Token" };
            }
            _refreshTokenWriteRepository.Remove(existRefreshToken);
            await _unitOfWork.CommitIdentityAsync();
            return new Response<NoDataDto>() { Succeeded = true, Message = "Refresh Token Revoked" };
        }

        private async void AddAbout(string userId )
        {
            var userAccountAbout = new UserAccountAbout()
            {
                AppUserId = userId,
                Biography = "",
                JobTitle = ""
            };
            await _aboutWriteRepository.AddAsync(userAccountAbout);
        }
    }
}
