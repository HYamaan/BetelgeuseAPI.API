using BetelgeuseAPI.Application.Features.Commands.Category.BlogCategory.UploadBlogCategory;
using BetelgeuseAPI.Application.Features.Commands.Category.CourseCategory.UploadCourseCategory;
using BetelgeuseAPI.Application.Features.Commands.Category.DeleteCategory;
using BetelgeuseAPI.Application.Features.Commands.Category.EBookCategory.UploadEBookCategory;
using BetelgeuseAPI.Application.Features.Queries.Category.BlogCategory.GetBlogCategory;
using BetelgeuseAPI.Application.Features.Queries.Category.CourseCategory.GetCourseCategory;
using BetelgeuseAPI.Application.Features.Queries.Category.GetAllCategory;
using BetelgeuseAPI.Application.Features.Queries.Category.GetEBookCategory.GetEBookCategory;
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


        [HttpPost("[action]")]
        public async Task<IActionResult> UploadBlogCategory([FromBody] UploadBlogCategoryCommandRequest request)
        {
            UploadBlogCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadEBookCategory([FromBody] UploadEBookCategoryCommandRequest request)
        {
            UploadEBookCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadCourseCategory([FromBody] UploadCourseCategoryCommandRequest request)
        {
            UploadCourseCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetBlogCategory()
        {
            GetBlogCategoryCommandRequest request = new GetBlogCategoryCommandRequest();
            GetBlogCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCourseCategory()
        {
            GetCourseCategoryCommandRequest request = new GetCourseCategoryCommandRequest();
            GetCourseCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetEBookCategory()
        {
            GetEBookCategoryCommandRequest request = new GetEBookCategoryCommandRequest();
            GetEBookCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
