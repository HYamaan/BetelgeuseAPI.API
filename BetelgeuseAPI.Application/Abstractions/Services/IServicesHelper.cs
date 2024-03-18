using BetelgeuseAPI.Domain.Auth;

namespace BetelgeuseAPI.Application.Abstractions.Services;

public interface IServicesHelper
{
    string GetUserIdFromContext();
    Task<AppUser> GetUserById(string userId);
}