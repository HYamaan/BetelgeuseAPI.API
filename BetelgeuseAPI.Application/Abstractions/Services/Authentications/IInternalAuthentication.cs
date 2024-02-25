using BetelgeuseAPI.Application.Features.Commands.AppUser.CreateUser;
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetelgeuseAPI.Application.Abstractions.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsync(CreateUserCommandRequest request, string origin);
    }
}
