namespace BetelgeuseAPI.Application.DTOs.Response.Account;

public class LoginResponseDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }
    public bool IsVerified { get; set; }
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
    public required DateTime RefreshTokenExpiration { get; set; }
    public required DateTime AccessTokenExpiration { get; set; }
}