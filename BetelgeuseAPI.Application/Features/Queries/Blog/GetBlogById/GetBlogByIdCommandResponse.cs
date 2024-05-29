using BetelgeuseAPI.Application.DTOs.Response.Blog;
using BetelgeuseAPI.Domain.Common;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.GetBlogById;

public class GetBlogByIdCommandResponse : ResponseMessageAndSucceeded
{
    public BlogResponseDto Data { get; set; }
}