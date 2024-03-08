using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.DTOs.Response.Blog;
using BetelgeuseAPI.Application.Features.Commands.Admin.Blog.BlogCategory.AddBlogCategory;
using BetelgeuseAPI.Application.Features.Commands.Admin.Blog.BlogCategory.DeleteBlogCategory;
using BetelgeuseAPI.Application.Features.Queries.Blog;
using BetelgeuseAPI.Application.Repositories.Admin.AddBlogCategory;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetelgeuseAPI.Persistence.Services;

public class BlogService:IBlogService
{
    private readonly IAddBlogCategoryReadRepository _addBlogCategoryRead;
    private readonly IAddBlogCategoryWriteRepository _addBlogCategoryWrite;

    public BlogService(IAddBlogCategoryWriteRepository addBlogCategoryWrite, IAddBlogCategoryReadRepository addBlogCategoryRead)
    {
        _addBlogCategoryWrite = addBlogCategoryWrite;
        _addBlogCategoryRead = addBlogCategoryRead;
    }

    public async Task<Response<AddBlogCategoryCommandResponse>> AddBlogCategory(AddBlogCategoryCommandRequest request)
    {
        var isValid = await _addBlogCategoryRead.GetSingleAsync(ux => ux.Title.Trim().ToLower() == request.Title.Trim().ToLower());

        if (isValid != null)
        {
            return Response<AddBlogCategoryCommandResponse>.Fail("Blog category daha önceden eklenmiş");
        }

        var blogCategory = new BlogCategories()
        {
            Title = request.Title,
            SubTitle = request.SubTitle
        };
        await _addBlogCategoryWrite.AddAsync(blogCategory);
        await _addBlogCategoryWrite.SaveAsync();
        return Response<AddBlogCategoryCommandResponse>.Success("Blog category eklendi.");
    }


    public async Task<Response<DeleteBlogCategoryCommandResponse>> DeleteBlogCategory(DeleteBlogCategoryCommandRequest request)
    {
        var blogCategory = await _addBlogCategoryRead.GetByIdAsync(request.Id);
        if (blogCategory == null)
        {
            return Response<DeleteBlogCategoryCommandResponse>.Fail("Blog category bulunamadı");
        }
        return Response<DeleteBlogCategoryCommandResponse>.Success($"{blogCategory.Title} silindi");
    }

    public async Task<Response<GetBlogCategoriesCommandResponse>> GetBlogCategoriesAsync()
    {
        var result = await _addBlogCategoryRead.GetAll().Select(ux=> new BlogCategoryResponseDto()
        {
            Id = ux.Id,
            Title = ux.Title,
            SubTitle = ux.SubTitle
        }).ToListAsync();

        return Response<GetBlogCategoriesCommandResponse>.Success(new GetBlogCategoriesCommandResponse()
        {
            Data = result
        });
    }
}