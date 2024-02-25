using System.IdentityModel.Tokens.Jwt;
using BetelgeuseAPI.Application.DTOs;
using BetelgeuseAPI.Domain.Auth;

namespace BetelgeuseAPI.Application.Abstractions.Token;

public interface ITokenHandler
{
    //DTOs.Token CreateAccessToken(int minute);
    TokenDto CreateToken(AppUser appUser);

    Task<JwtSecurityToken> GenerateJWToken(AppUser user);
    RefreshToken GenerateRefreshToken(string ipAddress);
}