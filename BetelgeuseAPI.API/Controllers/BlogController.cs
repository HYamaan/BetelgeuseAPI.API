using BetelgeuseAPI.Application.Features.Commands.Blog.CreateBlog;
using BetelgeuseAPI.Application.Features.Commands.Blog.DeleteBlog;
using BetelgeuseAPI.Application.Features.Queries.Blog.BlogByCategory;
using BetelgeuseAPI.Application.Features.Queries.Blog.BlogByPagination;
using BetelgeuseAPI.Application.Features.Queries.Blog.BlogByUser;
using BetelgeuseAPI.Application.Features.Queries.Blog.GetAllBlogs;
using BetelgeuseAPI.Application.Features.Queries.Blog.GetBlogById;
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


    [Authorize]
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateBlog([FromForm] CreateBlogCommandRequest model)
    {
        CreateBlogCommandResponse response = await _mediator.Send(model);
        return Ok(response);
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllBlogs()
    {
        GetAllBlogsCommandRequest request = new GetAllBlogsCommandRequest();
        GetAllBlogsCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> GetBlogByCategories([FromQuery] GetBlogByCategoryCommandRequest request)
    {
        GetBlogByCategoryCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetBlogByUser([FromQuery] GetBlogByUserCommandRequest request)
    {
        GetBlogByUserCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetBlogById([FromQuery] GetBlogByIdCommandRequest request)
    {
        GetBlogByIdCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetBlogByPagination([FromQuery] GetBlogByPaginationCommandRequest request)
    {
        GetBlogByPaginationCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }


    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteBlog([FromQuery] DeleteBlogCommandRequest model)
    {
        DeleteBlogCommandResponse response = await _mediator.Send(model);
        return Ok(response);
    }
}