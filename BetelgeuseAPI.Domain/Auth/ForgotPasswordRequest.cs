
using System.ComponentModel.DataAnnotations;

namespace BetelgeuseAPI.Domain.Auth
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
