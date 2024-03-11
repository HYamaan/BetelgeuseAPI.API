using BetelgeuseAPI.Application.DTOs.Response.Blog;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.BlogCategory;

public class GetBlogCategoriesCommandResponse : ResponseMessageAndSucceeded
{
    public List<BlogCategoryResponseDto> Data { get; set; }
}