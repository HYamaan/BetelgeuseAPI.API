using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.Abstractions.Services.Helpers;

public interface IFileCheckHelper
{
    Task<bool> CheckVideoFormat(IFormFile file);
    Task<bool> CheckPdfFormat(IFormFile file);
    Task<bool> CheckPPTFormat(IFormFile file);
}