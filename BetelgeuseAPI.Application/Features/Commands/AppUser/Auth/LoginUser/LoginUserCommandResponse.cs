using System.Text.Json.Serialization;
using BetelgeuseAPI.Application.DTOs.Response.Account;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.LoginUser
{
    public class LoginUserCommandResponse : ResponseMessageAndSucceeded
    {
        public LoginResponseDto Data { get; set; }
    }

}