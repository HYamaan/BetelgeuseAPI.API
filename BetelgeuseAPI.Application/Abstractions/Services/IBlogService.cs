using BetelgeuseAPI.Application.Features.Commands.Blog.AddBlogCategory;
using BetelgeuseAPI.Application.Features.Commands.Blog.CreateBlog;
using BetelgeuseAPI.Application.Features.Commands.Blog.DeleteBlog;
using BetelgeuseAPI.Application.Features.Commands.Blog.DeleteBlogCategory;
using BetelgeuseAPI.Application.Features.Queries.Blog.BlogByCategory;
using BetelgeuseAPI.Application.Features.Queries.Blog.BlogByPagination;
using BetelgeuseAPI.Application.Features.Queries.Blog.BlogByUser;
using BetelgeuseAPI.Application.Features.Queries.Blog.BlogCategory;
using BetelgeuseAPI.Application.Features.Queries.Blog.GetAllBlogs;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Abstractions.Services;

public interface IBlogService
{
    Task<Response<AddBlogCategoryCommandResponse>> AddBlogCategory(AddBlogCategoryCommandRequest request);
    Task<Response<CreateBlogCommandResponse>> CreateBlog(CreateBlogCommandRequest request);

    Task<Response<GetBlogCategoriesCommandResponse>> GetBlogCategoriesAsync();
    Task<Response<GetBlogByUserCommandResponse>> GetBlogByUserAsync(GetBlogByUserCommandRequest request);
     Task<Response<GetAllBlogsCommandResponse>> GetAllBlogsAsync();

    Task<Response<GetBlogByCategoryCommandResponse>> GetBlogByCategoryAsync(GetBlogByCategoryCommandRequest request);

    Task<Response<GetBlogByPaginationCommandResponse>> GetBlogByPaginationAsync(GetBlogByPaginationCommandRequest request);

    Task<Response<DeleteBlogCategoryCommandResponse>> DeleteBlogCategory(DeleteBlogCategoryCommandRequest request);
    Task<Response<DeleteBlogCommandResponse>> DeleteBlog(DeleteBlogCommandRequest request);
}