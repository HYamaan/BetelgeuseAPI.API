using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Abstractions.Storage;
using BetelgeuseAPI.Application.DTOs.Response.Blog;
using BetelgeuseAPI.Application.Features.Commands.Blog.BlogCategory.AddBlogCategory;
using BetelgeuseAPI.Application.Features.Commands.Blog.BlogCategory.DeleteBlogCategory;
using BetelgeuseAPI.Application.Features.Commands.Blog.CreateBlog;
using BetelgeuseAPI.Application.Features.Queries.Blog.BlogByCategory;
using BetelgeuseAPI.Application.Features.Queries.Blog.BlogCategory;
using BetelgeuseAPI.Application.Repositories.Blog.AddBlogCategory;
using BetelgeuseAPI.Application.Repositories.Blog.BlogImage;
using BetelgeuseAPI.Application.Repositories.Blog.CreateBlog;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;

namespace BetelgeuseAPI.Persistence.Services;

public class BlogService : IBlogService
{
    private readonly IServicesHelper _servicesHelper;
    private readonly IStorageService _storageService;

    private readonly IBlogImageReadRepository _blogImageFileReadRepository;
    private readonly IBlogImageWriteRepository _blogImageFileWriteRepository;
    private readonly IAddBlogCategoryReadRepository _addBlogCategoryRead;
    private readonly IAddBlogCategoryWriteRepository _addBlogCategoryWrite;
    private readonly IBlogWriteRepository _blogWrite;
    private readonly IBlogReadRepository _blogRead;

    public BlogService(IAddBlogCategoryWriteRepository addBlogCategoryWrite, IAddBlogCategoryReadRepository addBlogCategoryRead, IServicesHelper servicesHelper, IStorageService storageService, IBlogImageWriteRepository blogImageFileWriteRepository, IBlogImageReadRepository blogImageFileReadRepository, IBlogWriteRepository blogWrite, IBlogReadRepository blogRead)
    {
        _addBlogCategoryWrite = addBlogCategoryWrite;
        _addBlogCategoryRead = addBlogCategoryRead;
        _servicesHelper = servicesHelper;
        _storageService = storageService;
        _blogImageFileWriteRepository = blogImageFileWriteRepository;
        _blogImageFileReadRepository = blogImageFileReadRepository;
        _blogWrite = blogWrite;
        _blogRead = blogRead;
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
        var result = await _addBlogCategoryRead.GetAll().Select(ux => new BlogCategoryResponseDto()
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

    public async Task<Response<CreateBlogCommandResponse>> CreateBlog(CreateBlogCommandRequest request)
    {
        var userID = _servicesHelper.GetUserIdFromContext();

        var newBlogs = new Blogs()
        {
            Title = request.Title,
            BlogCategoriesID = request.BlogCategoriesID,
            Keywords = request.Keywords,
            Description = request.Description,
            Content = request.Content,
            BlogImage = new BlogImage(),
            AppUserId = userID
        };
        var profilePhoto = await SaveImage(request.BlogImage, userID);
        newBlogs.BlogImage = profilePhoto;
        newBlogs.BlogImageID = profilePhoto.Id;

        await _blogWrite.AddAsync(newBlogs);
        await _blogWrite.SaveAsync();
        return Response<CreateBlogCommandResponse>.Success("Blog eklendi");
    }

    public async Task<Response<GetBlogByCategoryCommandResponse>> GetBlogByCategoryAsync(GetBlogByCategoryCommandRequest request)
    {
        var result = _blogRead.GetWhere(ux => ux.BlogCategoriesID == request.CategoryId).Select(ux => new BlogResponseDto()
        {
            Id = ux.Id,
            Title = ux.Title,
            Keywords = ux.Keywords,
            Description = ux.Description,
            Content = ux.Content,
            BlogCategoriesID = ux.BlogCategoriesID,
            BlogImageID = ux.BlogImage.Id,
            BlogImage = ux.BlogImage,
            AppUserId = ux.AppUserId
        }).ToListAsync();
        return Response<GetBlogByCategoryCommandResponse>.Success(new GetBlogByCategoryCommandResponse()
        {
            Data = await result
        });
    }

    private async Task<BlogImage> SaveImage(IFormFile image, string userId)
    {


        var (fileName, pathOrContainerName) = await _storageService.UploadAsync("files", image);
        var userProfileImage = new BlogImage()
        {
            FileName = fileName,
            Path = pathOrContainerName,
            Storage = _storageService.StorageName,
            AppUserId = userId,
        };
        await _blogImageFileWriteRepository.AddAsync(userProfileImage);
        await _blogImageFileWriteRepository.SaveAsync();
        return userProfileImage;

    }

    private async Task<BlogImage> UpdateImage(IFormFile image, string userId, Blogs blog)
    {
        var profilePhoto = await _blogImageFileReadRepository.GetWhere(ux => ux.AppUserId == userId).FirstOrDefaultAsync();

        if (profilePhoto == null)
        {
            var (fileName, pathOrContainerName) = await _storageService.UploadAsync("files", image);
            var userProfileImage = new BlogImage()
            {
                FileName = fileName,
                Path = pathOrContainerName,
                Storage = _storageService.StorageName,
                AppUserId = userId,

            };
            await _blogImageFileWriteRepository.AddAsync(userProfileImage);
            await _blogImageFileWriteRepository.SaveAsync();
            return userProfileImage;
        }
        else
        {

            await _storageService.DeleteAsync(profilePhoto.Path.Split(Path.DirectorySeparatorChar)[0], profilePhoto.FileName);
            var (fileName, pathOrContainerName) = await _storageService.UploadAsync("files", image);
            profilePhoto.FileName = fileName;
            profilePhoto.Path = pathOrContainerName;
            _blogImageFileWriteRepository.Update(profilePhoto);
            await _blogImageFileWriteRepository.SaveAsync();
            return profilePhoto;
        }


    }
}