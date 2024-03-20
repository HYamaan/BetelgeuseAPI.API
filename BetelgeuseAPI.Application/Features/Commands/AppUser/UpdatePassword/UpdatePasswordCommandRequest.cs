using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.UpdatePassword
{
    public class UpdatePasswordCommandRequest : IRequest<UpdatePasswordCommandResponse>
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
