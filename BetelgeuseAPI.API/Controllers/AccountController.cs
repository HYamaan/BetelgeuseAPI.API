﻿using BetelgeuseAPI.Application.Features.Commands.AppUser.CreateUser;
using BetelgeuseAPI.Application.Features.Commands.AppUser.LoginUser;
using BetelgeuseAPI.Application.Features.Commands.AppUser.UpdatePassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using BetelgeuseAPI.Application.DTOs.Request.Account;
using BetelgeuseAPI.Application.Features.Commands.AppUser.ChangePassword;
using BetelgeuseAPI.Application.Features.Commands.AppUser.ForgetPassword;

namespace BetelgeuseAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse createUserCommandResponse = await _mediator.Send(createUserCommandRequest);
            return Ok(createUserCommandResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            LoginUserCommandRequest loginUserCommandRequest = new LoginUserCommandRequest()
            {
                Email = loginUser.Email,
                Password = loginUser.Password,
                IPAddress = GenerateIpAddress()
            };
            LoginUserCommandResponse loginUserCommandResponse = await _mediator.Send(loginUserCommandRequest);
            return Ok(loginUserCommandResponse);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(
            [FromBody] ChangePasswordCommandRequest changePasswordCommandRequest)
        {
            ChangePasswordCommandResponse response = await _mediator.Send(changePasswordCommandRequest);
            return Ok(response);
        }

        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgotPassword(ForgetPasswordRequest ForgetPasswordRequest)
        {
            ForgetPasswordCommandRequest forgetPasswordCommandRequest = new ForgetPasswordCommandRequest();
            forgetPasswordCommandRequest.Headers = Request.Headers["origin"];
            forgetPasswordCommandRequest.Email = ForgetPasswordRequest.Email;
            await _mediator.Send(forgetPasswordCommandRequest);
           return Ok();
        }

        [HttpPost("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommandRequest updatePasswordCommandRequest)
        {
            UpdatePasswordCommandResponse response = await _mediator.Send(updatePasswordCommandRequest);
            return Ok(response);
        }

        private string GenerateIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
