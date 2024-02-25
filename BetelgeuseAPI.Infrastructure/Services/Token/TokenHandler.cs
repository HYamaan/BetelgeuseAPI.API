using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BetelgeuseAPI.Application.Abstractions.Token;
using BetelgeuseAPI.Application.DTOs;
using BetelgeuseAPI.Application.Helpers;
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.CompilerServices;

namespace BetelgeuseAPI.Infrastructure.Services.Token;

public class TokenHandler : ITokenHandler
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<AppUser> _userManager;
    private readonly JWTSettings _jwtSettings;

    public TokenHandler(IConfiguration configuration,
        UserManager<AppUser> userManager,
        IOptions<JWTSettings> jwtSettings)
    {
        _configuration = configuration;
        _userManager = userManager;
        _jwtSettings = jwtSettings.Value;
    }
    private string RandomTokenString()
    {
        using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
        var randomBytes = new byte[40];
        rngCryptoServiceProvider.GetBytes(randomBytes);
        // convert random bytes to hex string
        return BitConverter.ToString(randomBytes).Replace("-", "");
    }

    private IEnumerable<Claim> GetClaims(AppUser appUser, List<String> audiences)
    {
        var userList = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier,appUser.Id),
            new Claim(JwtRegisteredClaimNames.Email, appUser.Email),
            new Claim(ClaimTypes.Name,appUser.UserName),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
        };

        userList.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

        return userList;
    }

    public TokenDto CreateToken(AppUser appUser)
    {
        var accessTokenExpiration = DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpiration);
        var refreshTokenExpiration = DateTime.Now.AddMinutes(_jwtSettings.RefreshTokenExpiration);
        var securityKey = GetSecurityKey.GetSymmetricSecurityKey(_jwtSettings.SecurityKey);
        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            expires: accessTokenExpiration,
            audience: _jwtSettings.Audience[0],
            claims: GetClaims(appUser,_jwtSettings.Audience),
            signingCredentials: signingCredentials);
        var handler = new JwtSecurityTokenHandler();
        var token = handler.WriteToken(jwtSecurityToken);

        var tokenDto = new TokenDto
        {
            AccessToken = token,
            RefreshToken = RandomTokenString(),
            AccessTokenExpiration = accessTokenExpiration,
            RefreshTokenExpiration = refreshTokenExpiration
        };

        return tokenDto;
    }




















    public async Task<JwtSecurityToken> GenerateJWToken(AppUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);
        var roleClaims = new List<Claim>();
        roleClaims.AddRange(roles.Select(role => new Claim("roles", role)));


        var ipAddress = IpHelper.GetIpAddress();

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id),
            new Claim("ip", ipAddress)
        }
            .Union(userClaims)
            .Union(roleClaims);
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var accessTokenExpiration = DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpiration);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            expires: accessTokenExpiration,
            audience: _jwtSettings.Audience[0],
            claims: claims,
            signingCredentials: signingCredentials);
        return jwtSecurityToken;
    }














    public RefreshToken GenerateRefreshToken(string ipAddress)
    {
        return new RefreshToken
        {
            Token = RandomTokenString(),
            Expires = DateTime.UtcNow.AddDays(7),
            Created = DateTime.UtcNow,
            CreatedByIp = ipAddress
        };
    }


    //public Application.DTOs.Token CreateAccessToken(int minute)
    //{
    //    //TODO: Remove this method and use GenerateJWToken method
    //    Application.DTOs.Token token = new();

    //    SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
    //    SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);
    //    token.ExpirationTime = DateTime.UtcNow.AddMinutes(minute);
    //    JwtSecurityToken jwtSecurityToken = new(
    //        issuer: _configuration["Token:Issuer"],
    //        audience: _configuration["Token:Audience"],
    //        expires: token.ExpirationTime,
    //        notBefore: DateTime.UtcNow,
    //        signingCredentials: signingCredentials
    //    );
    //    JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
    //    token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
    //    return token;

    //}
}