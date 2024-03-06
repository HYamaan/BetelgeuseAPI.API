namespace BetelgeuseAPI.Application.DTOs.Request.Account
{
    public class LoginAccountRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string IPAddress { get; set; }
    }
}
