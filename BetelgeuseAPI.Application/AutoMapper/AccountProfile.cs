using AutoMapper;
using BetelgeuseAPI.Application.DTOs.Request.Account;
using BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.LoginUser;
using BetelgeuseAPI.Application.Features.Commands.AppUser.ForgetPassword;

namespace BetelgeuseAPI.Application.AutoMapper
{
    public class AccountProfile:Profile
    {
        public AccountProfile()
        {
            CreateMap<LoginAccountRequest, LoginUserCommandRequest>().ReverseMap();
            CreateMap<ForgetPasswordRequest, ForgetPasswordCommandRequest>().ReverseMap();
        }
    }
}
