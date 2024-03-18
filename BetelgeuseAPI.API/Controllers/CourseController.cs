using BetelgeuseAPI.Application.Features.Commands.Course.BasicInformation;
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
        public async Task<IActionResult> CreateCourse([FromForm] BasicInformationCommandRequest model)
        {
            BasicInformationCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }
    }
}
