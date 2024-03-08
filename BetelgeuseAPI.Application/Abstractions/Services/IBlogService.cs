using BetelgeuseAPI.Application.Features.Commands.Admin.Blog.BlogCategory.AddBlogCategory;
using BetelgeuseAPI.Application.Features.Commands.Admin.Blog.BlogCategory.DeleteBlogCategory;
using BetelgeuseAPI.Application.Features.Queries.Blog;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Abstractions.Services;

public interface IBlogService
{
    Task<Response<AddBlogCategoryCommandResponse>> AddBlogCategory(AddBlogCategoryCommandRequest request);
    Task<Response<DeleteBlogCategoryCommandResponse>> DeleteBlogCategory(DeleteBlogCategoryCommandRequest request);
    Task<Response<GetBlogCategoriesCommandResponse>> GetBlogCategoriesAsync();
}