using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.LoginUser;

public class LoginUser
{
    [EmailAddress]
    public string? Email { get; set; }
    public string? Password { get; set; }
}