using BetelgeuseAPI.Application.Abstractions.Storage;
using BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.DeleteProfileBackgroundImage;
using BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.DeleteProfileImage;
using BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.UploadProfileBackgroundImage;
using BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.UploadProfileImage;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.AddAccountEducation;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.AddAccountExperiences;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Education.DeleteAccountEducation;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Education.UpdateAccountEducation;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Experience.DeleteAccountExperience;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Experience.UpdateAccountExperience;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.UpdateAccountAbout;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.UploadAccountInformation;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.UserSkill.AddUserSkill;
using BetelgeuseAPI.Application.Features.Queries.GetAllUserSkills;
using BetelgeuseAPI.Application.Features.Queries.ProfileImageFile.GetProfileBackgroundImage;
using BetelgeuseAPI.Application.Features.Queries.ProfileImageFile.GetProfileImage;
using BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountAbout;
using BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountEducation;
using BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountExperiences;
using BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountSkill;
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
        private readonly IStorageService _storageService;
        private readonly IVideoUploadFileWriteRepository _videoUploadFileWriteRepository;
        public UserController(IStorageService storageService,
            IVideoUploadFileWriteRepository videoUploadFileWriteRepository, 
            IMediator mediator)
        {
            _storageService = storageService;
            _videoUploadFileWriteRepository = videoUploadFileWriteRepository;
            _mediator = mediator;
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadProfileImage([FromQuery] UploadProfileImageCommandRequest model)
        {
            model.profileImage = Request.Form.Files[0];
            UploadProfileImageCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadProfileBackgroundImage([FromQuery] UploadProfileBackgroundImageCommandRequest model)
        {
            model.profileBackgroundImage = Request.Form.Files[0];
            UploadProfileBackgroundImageCommandResponse response = await _mediator.Send(model);
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
        [HttpPost("[action]")]
        public async Task<IActionResult> AddUserSkill([FromBody] AddUserSkillCommandRequest model)
        {
            AddUserSkillCommandResponse response = await _mediator.Send(model);
            return Ok(response);
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
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProfileImage()
        {
            var request = new GetProfileImageCommandRequest();
            GetProfileImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProfileBackgroundImage()
        {
            var request = new GetProfileBackgroundImageCommandRequest();
            GetProfileBackgroundImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUserSkills()
        {
            var model = new GetAllUserSkillsCommandRequest();
            GetAllUserSkillsCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserSkills ()
        {
            var model = new GetAccountSkillCommandRequest();
            GetAccountSkillCommandResponse response = await _mediator.Send(model);
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

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteProfileImage()
        {
            var request = new DeleteProfileImageCommandRequest();
            DeleteProfileImageCommandResponse response = await _mediator.Send(request)!;
            return Ok(response);
        }
        
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteProfileBackgroundImage()
        {
            var request = new DeleteProfileBackgroundImageCommandRequest();
            DeleteProfileBackgroundPhotoCommandResponse response = await _mediator.Send(request)!;
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
