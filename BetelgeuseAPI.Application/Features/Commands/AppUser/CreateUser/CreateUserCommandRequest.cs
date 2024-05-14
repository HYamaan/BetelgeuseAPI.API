using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.CreateUser;

public class CreateUserCommandRequest:IRequest<CreateUserCommandResponse>
{
    public required string FullName { get; set; }
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    [Required]
    [MinLength(6)]
    public required  string Password { get; set; }
    [Required]
    [MinLength(6)]
    public required string PasswordConfirm { get; set; }
}