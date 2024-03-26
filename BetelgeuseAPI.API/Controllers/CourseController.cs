using BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.CourseQuestion.UpdateCourseQuestion;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.DeleteCourseQuestion;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.UploadCourseQuiz;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseSection.UpdateCourseSection;
using BetelgeuseAPI.Application.Features.Commands.Course.Delete.DeleteCourseSection;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.BasicInformation;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseExtraInformation;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CoursePricing;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseQuestion;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseQuizes;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseSections;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseSource;
using BetelgeuseAPI.Application.Features.Queries.Course.GetBasicInformation;
using BetelgeuseAPI.Application.Features.Queries.Course.GetContent;
using BetelgeuseAPI.Application.Features.Queries.Course.GetExtraInformation;
using BetelgeuseAPI.Application.Features.Queries.Course.GetPricing;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetelgeuseAPI.API.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadBasicInformation([FromForm] BasicInformationCommandRequest model)
        {
            model.Thumbnail = Request.Form.Files[0];
            model.CoverImage = Request.Form.Files[0];
            BasicInformationCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadExtraInformation([FromBody] CourseExtraInformationCommandRequest model)
        {
            CourseExtraInformationCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadPricing([FromBody] CoursePricingCommandRequest model)
        {
            CoursePricingCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }


        [HttpPost("[action]")]
        public async Task<IActionResult> UploadSections([FromBody] CourseSectionsCommandRequest model)
        {
            CourseSectionsCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadSource([FromForm] CourseSourceCommandRequest model)
        {
            if (model.uploadFile != null)
            {
                model.uploadFile = Request.Form.Files[0];
            }
            CourseSourceCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadQuiz([FromBody] CourseQuizCommandRequest model)
        {
            CourseQuizCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadQuestion([FromForm] CourseQuestionCommandRequest model)
        {
            CourseQuestionCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateSection([FromBody] UpdateCourseSectionCommandRequest model)
        {
            UpdateCourseSectionCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateQuiz([FromBody] UploadCourseQuizCommandRequest model)
        {
            UploadCourseQuizCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateQuestion([FromForm] UpdateCourseQuestionCommandRequest model)
        {
            UpdateCourseQuestionCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBasicInformation([FromBody] GetBasicInformationCommandRequest model)
        {
            GetBasicInformationCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetExtraInformation([FromBody] GetExtraInformationCommandRequest model)
        {
            GetExtraInformationCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPricing([FromBody] GetPricingCommandRequest model)
        {
            GetPricingCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetContent([FromBody] GetContentCommandRequest model)
        {
            GetContentCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        

    
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteSection([FromBody] DeleteCourseSectionCommandRequest model)
        {
           
            DeleteCourseSectionCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteQuestion([FromBody] DeleteCourseQuestionCommandRequest model)
        {
            DeleteCourseQuestionCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }


    }
}
