using Microsoft.AspNetCore.Mvc;
using MediatR;
using BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.CreateTokenByRefreshToken;
using BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.LoginUser;
using BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.RevokeRefreshToken;
using BetelgeuseAPI.API.Helpers;
using BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.GoogleLogin;

namespace BetelgeuseAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            LoginUserCommandRequest loginUserCommandRequest = new LoginUserCommandRequest()
            {
                Email = loginUser.Email,
                Password = loginUser.Password,
                IPAddress = IpAddressHelper.GenerateIpAddress(Request)
        };
            LoginUserCommandResponse loginUserCommandResponse = await _mediator.Send(loginUserCommandRequest);
            return Ok(loginUserCommandResponse);
        }

        [HttpPost("refresh-token-login")]
        public async Task<IActionResult> RefreshTokenLogin(RefreshTokenLoginCommandRequest refreshTokenLogin)
        {
            refreshTokenLogin.IPAddress = IpAddressHelper.GenerateIpAddress(Request);

            RefreshTokenLoginCommandResponse createTokenByRefreshTokenCommandResponse = await _mediator.Send(refreshTokenLogin);

            return Ok(createTokenByRefreshTokenCommandResponse);
        }
        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest googleLoginCommandRequest)
        {
            googleLoginCommandRequest.IpAddress = IpAddressHelper.GenerateIpAddress(Request);
            GoogleLoginCommandResponse response = await _mediator.Send(googleLoginCommandRequest);
            return Ok(response);
        }


        [HttpPost("revoke-refresh-token")]
        public async Task<IActionResult> RevokeRefreshToken(RevokeRefreshTokenCommandRequest revokeRefreshTokenCommandRequest)
        {

            RevokeRefreshTokenCommandResponse response = await _mediator.Send(revokeRefreshTokenCommandRequest);

            return Ok(response);
        }
    }
}
