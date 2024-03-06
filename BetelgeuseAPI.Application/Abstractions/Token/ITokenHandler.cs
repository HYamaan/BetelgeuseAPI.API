using System.IdentityModel.Tokens.Jwt;
using BetelgeuseAPI.Application.DTOs;
using BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.CreateTokenByRefreshToken;
using BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.RevokeRefreshToken;
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Abstractions.Token;

public interface ITokenHandler
{
    Task<TokenDto> GenerateJWToken(AppUser user);
}