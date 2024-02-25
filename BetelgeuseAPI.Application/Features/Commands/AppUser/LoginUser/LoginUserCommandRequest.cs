using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandRequest:LoginUser, IRequest<LoginUserCommandResponse>
    {
        public string? IPAddress { get; set; }
    }
}
