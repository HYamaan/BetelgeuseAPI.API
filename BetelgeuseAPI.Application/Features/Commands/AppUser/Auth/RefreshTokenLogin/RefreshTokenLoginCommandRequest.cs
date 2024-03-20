using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.CreateTokenByRefreshToken
{
    public class RefreshTokenLoginCommandRequest : IRequest<RefreshTokenLoginCommandResponse>
    {
        public string RefreshToken { get; set; }
        public string? IPAddress { get; set; }
    }
}
