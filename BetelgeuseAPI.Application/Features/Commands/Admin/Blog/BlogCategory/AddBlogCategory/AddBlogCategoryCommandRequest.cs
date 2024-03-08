using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Admin.Blog.BlogCategory.AddBlogCategory;

public class AddBlogCategoryCommandRequest : IRequest<AddBlogCategoryCommandResponse>
{
    public required string Title { get; set; }

    [MaxLength(80, ErrorMessage = "SubTitle field must be at most 80 characters long.")]
    public required string SubTitle { get; set; }
}