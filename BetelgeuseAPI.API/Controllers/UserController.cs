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
        public async Task<IActionResult> Upload(IFormFileCollection file)
        {
            var datas = await _storageService.UploadAsync("files", file);
            await _profileImageFileWriteRepository.AddRangeAsync(datas.Select(d => new UserProfileImage()
            {
                FileName = d.fileName,
                Path = d.pathOrContainerName,
                Storage = _storageService.StorageName
            }).ToList());
            await _profileImageFileWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
