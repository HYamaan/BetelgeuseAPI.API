using System.ComponentModel.DataAnnotations;
using BetelgeuseAPI.Application.Features.Commands.AppUser.LoginUser;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.LoginUser;

public class LoginUser
{
    [EmailAddress]
    public string? Email { get; set; }
    public  string? Password { get; set; }
}