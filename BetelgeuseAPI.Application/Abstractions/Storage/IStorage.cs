using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.Abstractions.Storage
{
    public interface IStorage
    {
        Task<(string fileName, string pathOrContainerName)> UploadAsync(string pathOrContainerName, IFormFile file);
        Task<List<(string fileName, string pathOrContainerName)>> UploadVideoAsync(string pathOrContainerName, IFormFile file);
        Task DeleteAsync(string pathOrContainerName, string fileName);
        List<string> GetFiles(string pathOrContainerName);
        bool HasFile(string pathOrContainerName, string fileName);
    }
}