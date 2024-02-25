using BetelgeuseAPI.Application.DTOs;
using BetelgeuseAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandResponse: ResponseMessageAndSucceeded
    {
        public Token Token { get; set; }
    }
}
