using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Abstractions.Storage;
using BetelgeuseAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using File = BetelgeuseAPI.Domain.Entities.File.File;

public class ImageService<T, R, W> : IImageService<T, R, W>
    where T : File, new()
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

        var file = new T
        {
            FileName = fileName,
            Path = pathOrContainerName,
            Storage = _storageService.StorageName,
            AppUserId = userId
        };

        await _writeRepository.AddAsync(file);
        await _writeRepository.SaveAsync();

        return file;
    }

    public async Task<T> UpdateImage(IFormFile image, string userId)
    {
        var profilePhoto = await _readRepository.GetWhere(ux => ux.AppUserId == userId).FirstOrDefaultAsync();

        if (profilePhoto == null)
        {
            return await SaveImage(image, userId);
        }
        else
        {
            await _storageService.DeleteAsync(profilePhoto.Path, profilePhoto.FileName);

            var (fileName, pathOrContainerName) = await _storageService.UploadAsync("files", image);

            profilePhoto.FileName = fileName;
            profilePhoto.Path = pathOrContainerName;

            _writeRepository.Update(profilePhoto);
            await _writeRepository.SaveAsync();

            return profilePhoto;
        }
    }
}
