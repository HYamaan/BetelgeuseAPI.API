using System.ComponentModel.DataAnnotations;

namespace BetelgeuseAPI.Application.DTOs.Request.Account;

public class ForgetPasswordRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}