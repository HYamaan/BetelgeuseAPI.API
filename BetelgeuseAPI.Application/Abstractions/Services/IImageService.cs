using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.Abstractions.Services;

public interface IImageService<T, R, W>
{
    Task<T> SaveImage(IFormFile image, string userId);
    Task<T> UpdateImage(IFormFile image, string userId);
}