namespace BetelgeuseAPI.Domain.Auth
{
    public class AuthenticationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? IPAddress { get; set; }
    }
}
