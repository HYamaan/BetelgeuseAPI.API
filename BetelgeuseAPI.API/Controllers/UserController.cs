using BetelgeuseAPI.Application.Abstractions.Storage;
using BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.RemoveProfileImage;
using BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.UploadProfileImage;
using BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.UploadProfilePhoto;
using BetelgeuseAPI.Application.Features.Queries.ProfileImageFile.GetProfileImage;
using BetelgeuseAPI.Application.Repositories.UserProfileImageFile;
using BetelgeuseAPI.Application.Repositories.VideoUploadFile;
using BetelgeuseAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BetelgeuseAPI.API.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IStorageService _storageService;
        private readonly IUserProfileImageFileWriteRepository _profileImageFileWriteRepository;
        private readonly IVideoUploadFileWriteRepository _videoUploadFileWriteRepository;
        public UserController(IWebHostEnvironment webHostEnvironment, IStorageService storageService, IUserProfileImageFileWriteRepository profileImageFileWriteRepository, IVideoUploadFileWriteRepository videoUploadFileWriteRepository, IMediator mediator)
        {
            _webHostEnvironment = webHostEnvironment;
            _storageService = storageService;
            _profileImageFileWriteRepository = profileImageFileWriteRepository;
            _videoUploadFileWriteRepository = videoUploadFileWriteRepository;
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadProfilImage([FromQuery] UploadProfilPhotoCommandRequest uploadProfilPhotoCommandRequest)
        {
            uploadProfilPhotoCommandRequest.File = Request.Form.Files[0];
            UploadProfilPhotoCommandResponse uploadProfilPhotoCommandResponse = await _mediator.Send(uploadProfilPhotoCommandRequest);
            return Ok(uploadProfilPhotoCommandResponse);
        }
        [HttpDelete("[action]/{Id}")]

        public async Task<IActionResult> DeleteProfileImage([FromRoute] RemoveProfilImageCommandRequest removeProfilImageCommandRequest)
        {
            RemoveProfilPhotoCommandResponse removeProfilPhotoCommandResponse = await _mediator.Send(removeProfilImageCommandRequest)!;
            return Ok(removeProfilPhotoCommandResponse);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetProfileImage([FromRoute] GetProfileImageCommandRequest getProfileImageCommandRequest)
        {
            GetProfilImageCommandResponse getProfilImageCommandResponse = await _mediator.Send(getProfileImageCommandRequest);
            return Ok(getProfilImageCommandResponse);
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
