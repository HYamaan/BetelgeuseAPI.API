using BetelgeuseAPI.Application.Features.Commands.Blog.BlogCategory.AddBlogCategory;
using BetelgeuseAPI.Application.Features.Commands.Blog.BlogCategory.DeleteBlogCategory;
using BetelgeuseAPI.Application.Features.Commands.Blog.CreateBlog;
using BetelgeuseAPI.Application.Features.Queries.Blog.BlogByCategory;
using BetelgeuseAPI.Application.Features.Queries.Blog.BlogCategory;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Abstractions.Services;

public interface IBlogService
{
    Task<Response<AddBlogCategoryCommandResponse>> AddBlogCategory(AddBlogCategoryCommandRequest request);
    Task<Response<DeleteBlogCategoryCommandResponse>> DeleteBlogCategory(DeleteBlogCategoryCommandRequest request);
    Task<Response<GetBlogCategoriesCommandResponse>> GetBlogCategoriesAsync();

    Task<Response<CreateBlogCommandResponse>> CreateBlog(CreateBlogCommandRequest request);
    Task<Response<GetBlogByCategoryCommandResponse>> GetBlogByCategoryAsync(GetBlogByCategoryCommandRequest request);
}