namespace BetelgeuseAPI.Application.DTOs;

public class Token
{
    public string AccessToken { get; set; }
    public DateTime  ExpirationTime{ get; set; }
    public string RefreshToken { get; set; }
}