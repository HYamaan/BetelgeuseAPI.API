using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.ChangePassword;

public class ChangePasswordCommandRequest:IRequest<ChangePasswordCommandResponse>
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [PasswordPropertyText]
    [MinLength(4)]
    public string? CurrentPassword { get; set; }
    [Required]
    [PasswordPropertyText]
    [MinLength(4)]
    public string? NewPassword { get; set; }
    [Required]
    [PasswordPropertyText]
    [MinLength(4)]
    [Compare(nameof(NewPassword), ErrorMessage = "Passwords don't match.")]
    public string?  ConfirmNewPassword { get; set; }
}