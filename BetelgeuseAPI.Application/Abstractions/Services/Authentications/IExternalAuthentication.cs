using BetelgeuseAPI.Application.DTOs;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Abstractions.Services.Authentications
{
    public interface IExternalAuthentication
    {
        Task<Response<TokenDto>> GoogleLoginAsync(string idToken, string IpAddress);
    }
}
