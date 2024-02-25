using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Abstractions.Services.Authentications
{
    public interface IExternalAuthentication
    {
        Task<Response<DTOs.Token>> GoogleLoginAsync(string idToken, int accessTokenLifeTime);
    }
}
