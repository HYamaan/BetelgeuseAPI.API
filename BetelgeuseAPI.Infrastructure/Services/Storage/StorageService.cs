﻿using BetelgeuseAPI.Application.Abstractions.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetelgeuseAPI.Infrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {
        readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName
        {
            get => _storage.GetType().Name;
        }



        public async Task DeleteAsync(string pathOrContainerName, string fileName)
            => await _storage.DeleteAsync(pathOrContainerName, fileName);

        public List<string> GetFiles(string pathOrContainerName)
            => _storage.GetFiles(pathOrContainerName);

        public bool HasFile(string pathOrContainerName, string fileName)
            => _storage.HasFile(pathOrContainerName, fileName);

        public Task<(string fileName, string pathOrContainerName)> UploadAsync(string pathOrContainerName,
            IFormFile file)
            => _storage.UploadAsync(pathOrContainerName, file);

        public Task<List<(string fileName, string pathOrContainerName)>> UploadVideoAsync(string pathOrContainerName,
            IFormFile file)
            => _storage.UploadVideoAsync(pathOrContainerName, file);
    }
}