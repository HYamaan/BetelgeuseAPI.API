﻿using BetelgeuseAPI.Application.Abstractions.Storage.Local;
using BetelgeuseAPI.Infrastructure.ffmpeg;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using System.IO;

namespace BetelgeuseAPI.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : Storage, ILocalStorage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }



        public async Task DeleteAsync(string path, string fileName)
            => File.Delete($"{path}\\{fileName}");

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory = new(path);
            return directory.GetFiles().Select(f => f.Name).ToList();
        }

        public new bool HasFile(string path, string fileName)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string filePath = Path.Combine(webRootPath, path, fileName);

            return File.Exists(filePath);
        }

        async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                //todo log!
                throw ex;
            }
        }
        public async Task<(string fileName, string pathOrContainerName)> UploadAsync(string path, IFormFile file)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            string fileNewName = await FileRenameAsync(path, file.FileName, HasFile);
            await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
            return (fileNewName, $"{path}\\{fileNewName}");
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadVideoAsync(string path, IFormFile file)
        {

            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            string fileNewName = Guid.NewGuid().ToString();
            await videoResolutionTask(uploadPath, fileNewName, file, _webHostEnvironment.WebRootPath);
            List<(string fileName, string pathOrContainerName)> transformedFilePaths = VideoResolutionFFMPEG.TransformedFilePaths;
            return transformedFilePaths;
        }

    }
}
