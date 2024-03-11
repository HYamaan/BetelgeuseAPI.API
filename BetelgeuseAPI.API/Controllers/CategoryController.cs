using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Features.Commands.Category.DeleteCategory;
using BetelgeuseAPI.Application.Features.Commands.Category.UploadCategory;
using BetelgeuseAPI.Application.Features.Queries.Category.GetAllCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BetelgeuseAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> UploadCategory([FromBody] UploadCategoryCommandRequest request)
        {
            UploadCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCategory()
        {
            GetParentCategoryCommandRequest request = new GetParentCategoryCommandRequest();
            GetParentCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCategory([FromQuery] DeleteCategoryCommandRequest request)
        {
            DeleteCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
