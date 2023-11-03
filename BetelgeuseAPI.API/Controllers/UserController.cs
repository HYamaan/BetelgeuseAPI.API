using BetelgeuseAPI.Application.Abstractions.Storage;
using BetelgeuseAPI.Application.Repositories.UserProfileImageFile;
using BetelgeuseAPI.Application.Repositories.VideoUploadFile;
using BetelgeuseAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BetelgeuseAPI.API.Controllers
{
    public class UserController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IStorageService _storageService;
        private readonly IUserProfileImageFileWriteRepository _profileImageFileWriteRepository;
        private readonly IVideoUploadFileWriteRepository _videoUploadFileWriteRepository;
        public UserController(IWebHostEnvironment webHostEnvironment, IStorageService storageService, IUserProfileImageFileWriteRepository profileImageFileWriteRepository, IVideoUploadFileWriteRepository videoUploadFileWriteRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _storageService = storageService;
            _profileImageFileWriteRepository = profileImageFileWriteRepository;
            _videoUploadFileWriteRepository = videoUploadFileWriteRepository;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var (fileName, pathOrContainerName) = await _storageService.UploadAsync("files", file);

            var userProfileImage = new UserProfileImage()
            {
                FileName = fileName,
                Path = pathOrContainerName,
                Storage = _storageService.StorageName
            };

            await _profileImageFileWriteRepository.AddAsync(userProfileImage);
            await _profileImageFileWriteRepository.SaveAsync();

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadVideo(IFormFile file)
        {
            var datas = await _storageService.UploadVideoAsync("files", file);

            await _videoUploadFileWriteRepository.AddRangeAsync(datas.Select(d => new VideoUploadModel()
            {
                FileName = d.fileName,
                Path = d.pathOrContainerName,
                Storage = _storageService.StorageName
            }).ToList());
            await _videoUploadFileWriteRepository.SaveAsync();

            return Ok();
        }

    }
}
