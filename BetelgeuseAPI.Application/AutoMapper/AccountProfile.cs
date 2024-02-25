using AutoMapper;
using BetelgeuseAPI.Application.DTOs.Request.Account;
using BetelgeuseAPI.Application.DTOs.Response.Account;
using BetelgeuseAPI.Application.Features.Commands.AppUser.ChangePassword;
using BetelgeuseAPI.Application.Features.Commands.AppUser.CreateUser;
using BetelgeuseAPI.Application.Features.Commands.AppUser.ForgetPassword;
using BetelgeuseAPI.Application.Features.Commands.AppUser.LoginUser;
using BetelgeuseAPI.Application.Features.Commands.AppUser.UpdatePassword;
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.AutoMapper
{
    public class AccountProfile:Profile
    {
        public AccountProfile()
        {
            CreateMap<CreateAccountRequest, CreateUserCommandRequest>().ReverseMap();
            CreateMap<Response<CreateAccountResponse>, CreateUserCommandResponse>().ReverseMap();
            CreateMap<LoginAccountRequest, LoginUserCommandRequest>().ReverseMap();
            CreateMap<Response<LoginAccountResponse>,LoginUserCommandResponse>().ReverseMap();
            CreateMap<ResetPasswordRequest, UpdatePasswordCommandRequest>().ReverseMap();
            CreateMap<ChangePasswordRequest, ChangePasswordCommandRequest>().ReverseMap();
            CreateMap<ForgetPasswordRequest, ForgetPasswordCommandRequest>().ReverseMap();
        }
    }
}
