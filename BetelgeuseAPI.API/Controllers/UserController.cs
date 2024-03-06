using BetelgeuseAPI.Application.Abstractions.Storage;
using BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.RemoveProfileImage;
using BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.UploadProfileImage;
using BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.UploadProfilePhoto;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.AddAccountEducation;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.AddAccountExperiences;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Education.DeleteAccountEducation;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Education.UpdateAccountEducation;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Experience.DeleteAccountExperience;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Experience.UpdateAccountExperience;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.UpdateAccountAbout;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.UploadAccountInformation;
using BetelgeuseAPI.Application.Features.Queries.ProfileImageFile.GetProfileImage;
using BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountAbout;
using BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountEducation;
using BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountExperiences;
using BetelgeuseAPI.Application.Repositories.UserProfileImageFile;
using BetelgeuseAPI.Application.Repositories.VideoUploadFile;
using BetelgeuseAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetelgeuseAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountCommandRequest model)
        {
            UpdateAccountCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAccountAbout([FromBody] UpdateAccountAboutCommandRequest model)
        {
            UpdateAccountAboutCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateEducation([FromBody] UpdateAccountEducationCommandRequest model)
        {
            UpdateAccountEducationCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateExperience([FromBody] UpdateAccountExperiencesCommandRequest model)
        {
            UpdateAccountExperiencesCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddExperiences ([FromBody] AddAccountExperiencesCommandRequest model)
        {
            AddAccountExperiencesCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddEducation ([FromBody] AddAccountEducationCommandRequest model)
        {
            AddAccountEducationCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetEducation ()
        {
            var model = new GetAccountEducationCommandRequest();
            GetAccountEducationCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetExperiences ()
        {
            var model = new GetAccountExperienceCommandRequest();
            GetAccountExperienceCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAbout ()
        {
            var model = new GetAccountAboutCommandRequest();
            GetAccountAboutCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteEducation ([FromQuery]DeleteAccountEducationCommandRequest model)
        {
            DeleteAccountEducationCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteExperience ([FromQuery]DeleteAccountExperiencesCommandRequest model)
        {
            DeleteAccountExperiencesCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]

        public async Task<IActionResult> DeleteProfileImage([FromRoute] RemoveProfilImageCommandRequest model)
        {
            RemoveProfilPhotoCommandResponse response = await _mediator.Send(model)!;
            return Ok(response);
        }
        
        
        

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetProfileImage([FromRoute] GetProfileImageCommandRequest model)
        {
            GetProfilImageCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadProfilImage([FromQuery] UploadProfilPhotoCommandRequest model)
        {
            model.File = Request.Form.Files[0];
            UploadProfilPhotoCommandResponse response = await _mediator.Send(model);
            return Ok(response);
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
