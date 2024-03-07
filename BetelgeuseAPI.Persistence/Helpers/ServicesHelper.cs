using System.Security.Claims;
using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Exceptions;
using BetelgeuseAPI.Domain.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BetelgeuseAPI.Persistence.Helpers;

public class ServicesHelper:IServicesHelper
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ServicesHelper(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetUserIdFromContext()
    {
        var userId = _httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            throw new UnauthorizedAccessException();
        }
        return userId;
    }
    public async Task<AppUser> GetUserById(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new ApiException("Kullanıcı bulunamadı");
        }
        return user;
    }
}