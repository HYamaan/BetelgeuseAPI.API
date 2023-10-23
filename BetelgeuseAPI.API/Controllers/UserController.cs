using BetelgeuseAPI.Application.Abstractions.Storage;
using BetelgeuseAPI.Application.Repositories.UserProfileImageFile;
using BetelgeuseAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BetelgeuseAPI.API.Controllers
{
    public class UserController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IStorageService _storageService;
        private readonly IUserProfileImageFileWriteRepository _profileImageFileWriteRepository;
        public UserController(IWebHostEnvironment webHostEnvironment, IStorageService storageService, IUserProfileImageFileWriteRepository profileImageFileWriteRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _storageService = storageService;
            _profileImageFileWriteRepository = profileImageFileWriteRepository;
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

    }
}
