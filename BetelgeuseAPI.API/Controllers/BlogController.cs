using BetelgeuseAPI.Application.Features.Commands.Blog.BlogCategory.AddBlogCategory;
using BetelgeuseAPI.Application.Features.Commands.Blog.BlogCategory.DeleteBlogCategory;
using BetelgeuseAPI.Application.Features.Commands.Blog.CreateBlog;
using BetelgeuseAPI.Application.Features.Queries.Blog.BlogByCategory;
using BetelgeuseAPI.Application.Features.Queries.Blog.BlogCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetelgeuseAPI.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BlogController : Controller
{
    private readonly IMediator _mediator;

    public BlogController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> AddBlogCategory([FromBody] AddBlogCategoryCommandRequest model)
    {
        AddBlogCategoryCommandResponse response = await _mediator.Send(model);
        return Ok(response);
    }
    [Authorize]
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateBlog([FromForm] CreateBlogCommandRequest model)
    {
        CreateBlogCommandResponse response = await _mediator.Send(model);
        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetBlogAllCategories()
    {
        GetBlogCategoriesCommandRequest request = new GetBlogCategoriesCommandRequest();
        GetBlogCategoriesCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteBlogCategory([FromBody] DeleteBlogCategoryCommandRequest model)
    {
        DeleteBlogCategoryCommandResponse response = await _mediator.Send(model);
        return Ok(response);
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> GetBlogByCategories([FromQuery] GetBlogByCategoryCommandRequest request)
    {
        GetBlogByCategoryCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }


}