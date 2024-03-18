using BetelgeuseAPI.Application.Features.Commands.Course.BasicInformation;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseExtraInformation;
using BetelgeuseAPI.Application.Features.Commands.Course.CoursePricing;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetelgeuseAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
