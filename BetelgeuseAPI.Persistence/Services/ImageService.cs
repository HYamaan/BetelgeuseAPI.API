using System.Net;
using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Abstractions.Storage;
using BetelgeuseAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using File = BetelgeuseAPI.Domain.Entities.File.File;

namespace BetelgeuseAPI.Persistence.Services;

public class ImageService<T, R, W> : IImageService<T, R, W>
    where T : File
    where R : IReadRepository<T>
    where W : IWriteRepository<T>
{
    private readonly IStorageService _storageService;
    private readonly R _readRepository;
    private readonly W _writeRepository;

    public ImageService(IStorageService storageService, R readRepository, W writeRepository)
    {
        _storageService = storageService;
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task<T> SaveImage(IFormFile image, string userId)
    {
        var (fileName, pathOrContainerName) = await _storageService.UploadAsync("files", image);
        if (fileName == null || pathOrContainerName == null)
        {
            return null;
        }

        var userProfileImage = Activator.CreateInstance<T>();
        typeof(T).GetProperty("FileName")?.SetValue(userProfileImage, fileName);
        typeof(T).GetProperty("Path")?.SetValue(userProfileImage, pathOrContainerName);
        typeof(T).GetProperty("Storage")?.SetValue(userProfileImage, _storageService.StorageName);
        typeof(T).GetProperty("AppUserId")?.SetValue(userProfileImage, userId);

        await _writeRepository.AddAsync(userProfileImage);
        await _writeRepository.SaveAsync();

        return userProfileImage;
    }

    public async Task<T> UpdateImage(IFormFile image, string userId)
    {
        var profilePhoto = await _readRepository.GetWhere(ux => typeof(T).GetProperty("AppUserId").GetValue(ux) == userId).FirstOrDefaultAsync();

        if (profilePhoto == null)
        {
            var (fileName, pathOrContainerName) = await _storageService.UploadAsync("files", image);
            var userProfileImage = Activator.CreateInstance<T>();
            typeof(T).GetProperty("FileName")?.SetValue(userProfileImage, fileName);
            typeof(T).GetProperty("Path")?.SetValue(userProfileImage, pathOrContainerName);
            typeof(T).GetProperty("Storage")?.SetValue(userProfileImage, _storageService.StorageName);
            typeof(T).GetProperty("AppUserId")?.SetValue(userProfileImage, userId);

            await _writeRepository.AddAsync(userProfileImage);
            await _writeRepository.SaveAsync();

            return userProfileImage;
        }
        else
        {
            await _storageService.DeleteAsync(profilePhoto.Path.Split(Path.DirectorySeparatorChar)[0], profilePhoto.FileName);
            var (fileName, pathOrContainerName) = await _storageService.UploadAsync("files", image);
            typeof(T).GetProperty("FileName")?.SetValue(profilePhoto, fileName);
            typeof(T).GetProperty("Path")?.SetValue(profilePhoto, pathOrContainerName);
            _writeRepository.Update(profilePhoto);
            await _writeRepository.SaveAsync();

            return profilePhoto;
        }
    }

}