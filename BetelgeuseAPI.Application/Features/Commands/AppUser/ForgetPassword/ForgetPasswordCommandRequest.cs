using System.ComponentModel.DataAnnotations;
using BetelgeuseAPI.Application.DTOs.Request.Account;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.ForgetPassword;

    public class ForgetPasswordCommandRequest:ForgetPasswordRequest,IRequest<ForgetPasswordCommandResponse>
    {
        public string Headers { get; set; }
    }