using System.Text.Json.Serialization;
using BetelgeuseAPI.Application.DTOs;
using BetelgeuseAPI.Application.DTOs.Response.Account;
using BetelgeuseAPI.Domain.Auth;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {
        public LoginAccountResponse Data { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }

   
    
}