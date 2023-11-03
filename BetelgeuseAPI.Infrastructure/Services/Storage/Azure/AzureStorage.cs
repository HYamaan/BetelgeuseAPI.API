using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BetelgeuseAPI.Application.Abstractions.Storage.Azure;
using BetelgeuseAPI.Infrastructure.ffmpeg;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetelgeuseAPI.Infrastructure.Services.Storage.Azure
{
    public class AzureStorage : Storage, IAzureStorage
    {
        readonly BlobServiceClient _blobServiceClient;
        BlobContainerClient _blobContainerClient;
        public AzureStorage(IConfiguration configuration)
        {
            _blobServiceClient = new(configuration["Storage:Azure"]);
        }


        public async Task DeleteAsync(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        public List<string> GetFiles(string containerName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Select(b => b.Name).ToList();
        }

        public bool HasFile(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);
        }

        public async Task<(string fileName, string pathOrContainerName)> UploadAsync(string containerName, IFormFile file)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            string fileNewName = await FileRenameAsync(containerName, file.Name, HasFile);

            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileNewName);
            await blobClient.UploadAsync(file.OpenReadStream());
            return (fileNewName, $"{containerName}/{fileNewName}");
        }
        public async Task<List<(string fileName, string pathOrContainerName)>> UploadVideoAsync(string containerName, IFormFile file)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            string fileNewName = await FileRenameAsync(containerName, file.Name, HasFile);
            await videoResolutionTask(containerName, fileNewName, file, containerName);
            List<(string fileName, string pathOrContainerName)> transformedFilePaths = VideoResolutionFFMPEG.TransformedFilePaths;
            //TODO:Local storega kısmı halledildi azure storage bağlandığı zaman bilgileri oradan bakarak düzenlemeye çalış, VideoResolutionFFMPEG sınıfında oluşuan dosyaları geri döndürmek gereklidir. 
            //TODO: file.OpenReadStream() dosyası ile veriler azure geçicek
            foreach ((string fileName, string pathOrContainerName) in transformedFilePaths)
            {
                BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
                await blobClient.UploadAsync(file.OpenReadStream());
            }

            return transformedFilePaths;
        }


    }
}
