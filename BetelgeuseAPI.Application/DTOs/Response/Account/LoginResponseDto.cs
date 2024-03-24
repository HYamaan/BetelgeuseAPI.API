namespace BetelgeuseAPI.Application.DTOs.Response.Account;

public class LoginResponseDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }
    public bool IsVerified { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}