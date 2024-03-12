using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Abstractions.Storage;
using BetelgeuseAPI.Application.DTOs.Response.Blog;
using BetelgeuseAPI.Application.Features.Commands.Blog.CreateBlog;
using BetelgeuseAPI.Application.Features.Queries.Blog.BlogByCategory;
using BetelgeuseAPI.Application.Repositories.Blog.BlogImage;
using BetelgeuseAPI.Application.Repositories.Blog.CreateBlog;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using BetelgeuseAPI.Application.Features.Queries.Blog.BlogByUser;
using BetelgeuseAPI.Application.Operations;
using BetelgeuseAPI.Application.Features.Commands.Blog.DeleteBlog;
using BetelgeuseAPI.Application.Features.Queries.Blog.BlogByPagination;
using BetelgeuseAPI.Application.Features.Queries.Blog.GetAllBlogs;
using BetelgeuseAPI.Application.Features.Queries.Blog.GetBlogById;
using Org.BouncyCastle.Asn1.Ocsp;

namespace BetelgeuseAPI.Persistence.Services;

public class BlogService : IBlogService
{
    private readonly IServicesHelper _servicesHelper;
    private readonly IStorageService _storageService;

    private readonly IBlogImageReadRepository _blogImageFileReadRepository;
    private readonly IBlogImageWriteRepository _blogImageFileWriteRepository;

    private readonly IBlogWriteRepository _blogWrite;
    private readonly IBlogReadRepository _blogRead;

    public BlogService(IServicesHelper servicesHelper, IStorageService storageService, IBlogImageWriteRepository blogImageFileWriteRepository, IBlogImageReadRepository blogImageFileReadRepository, IBlogWriteRepository blogWrite, IBlogReadRepository blogRead)
    {
        _servicesHelper = servicesHelper;
        _storageService = storageService;
        _blogImageFileWriteRepository = blogImageFileWriteRepository;
        _blogImageFileReadRepository = blogImageFileReadRepository;
        _blogWrite = blogWrite;
        _blogRead = blogRead;
    }



    public async Task<Response<CreateBlogCommandResponse>> CreateBlog(CreateBlogCommandRequest request)
    {
        var userID = _servicesHelper.GetUserIdFromContext();
        var seoTitle = NameOperation.CharacterRegulatory(request.Title.ToLower());
        var url = await _blogRead.BlogUrlControl(seoTitle.Replace(" ", "-"));

        var newBlogs = new Blogs()
        {
            Title = request.Title,
            BlogCategoryId = request.BlogCategoriesID,
            Description = request.Description,
            Content = request.Content,
            BlogImage = new BlogImage(),
            Status = BlogType.Pending.ToString(),
            MetaData = new MetaData()
            {
                MetaTitle = seoTitle,
                MetaKeywords = request.Keywords,
                Url = url
            }
        };
        var profilePhoto = await SaveImage(request.BlogImage, userID);
        newBlogs.BlogImage = profilePhoto;
        newBlogs.BlogImageID = profilePhoto.Id;

        await _blogWrite.AddAsync(newBlogs);
        await _blogWrite.SaveAsync();
        return Response<CreateBlogCommandResponse>.Success("Blog eklendi");
    }

    public async Task<Response<GetAllBlogsCommandResponse>> GetAllBlogsAsync()
    {
        var filteredBlogs = await _blogRead.GetFilteredBlogs(ux => ux.Status == BlogType.Pending.ToString()).ToListAsync();
        if (filteredBlogs.Count == 0)
            return Response<GetAllBlogsCommandResponse>.Fail("Kullanıcıya uygun bir veri bulunamadı");
        return Response<GetAllBlogsCommandResponse>.Success(new GetAllBlogsCommandResponse
        {
            Data = filteredBlogs
        });
    }

    public async Task<Response<GetBlogByCategoryCommandResponse>> GetBlogByCategoryAsync(GetBlogByCategoryCommandRequest request)
    {
        var filteredBlogs = await _blogRead.GetFilteredBlogs(ux => ux.BlogCategoryId == request.CategoryId).Include(ux=>ux.BlogCategoryID).ToListAsync();

        if (filteredBlogs.Count == 0)
            return Response<GetBlogByCategoryCommandResponse>.Fail("Kategoriye uygun bir veri bulunamadı");

        return Response<GetBlogByCategoryCommandResponse>.Success(new GetBlogByCategoryCommandResponse
        {
            Data = filteredBlogs
        });
    }

    public async Task<Response<GetBlogByPaginationCommandResponse>> GetBlogByPaginationAsync(GetBlogByPaginationCommandRequest request)
    {
        var take = 10;
        var filteredBlogs = await _blogRead.GetFilteredBlogs(ux => true).Skip(int.Parse(request.Index)).Take(take).ToListAsync();
        if (filteredBlogs.Count == 0)
            return Response<GetBlogByPaginationCommandResponse>.Fail("Uygun bir veri bulunamadı");
        return Response<GetBlogByPaginationCommandResponse>.Success(new GetBlogByPaginationCommandResponse
        {
            Data = filteredBlogs
        });

    }

    public async Task<Response<GetBlogByIdCommandResponse>> GetBlogById(GetBlogByIdCommandRequest request)
    {
        await _blogWrite.IncrementViewCount(request.Id);

        var filteredBlogs = await  _blogRead.GetFilteredBlogs(ux => ux.Id == request.Id).ToListAsync();
        

        if (filteredBlogs.Count == 0)
            return Response<GetBlogByIdCommandResponse>.Fail("Kullanıcıya uygun bir veri bulunamadı");

        return Response<GetBlogByIdCommandResponse>.Success(new GetBlogByIdCommandResponse
        {
            Data = filteredBlogs
        });
    }

    public async Task<Response<GetBlogByUserCommandResponse>> GetBlogByUserAsync(GetBlogByUserCommandRequest request)
    {
        var filteredBlogs = await _blogRead.GetFilteredBlogs(ux => ux.BlogImage.AppUserId == request.Id).ToListAsync();

        if (filteredBlogs.Count == 0)
            return Response<GetBlogByUserCommandResponse>.Fail("Kullanıcıya uygun bir veri bulunamadı");

        return Response<GetBlogByUserCommandResponse>.Success(new GetBlogByUserCommandResponse
        {
            Data = filteredBlogs
        });
    }
    

    public async Task<Response<DeleteBlogCommandResponse>> DeleteBlog(DeleteBlogCommandRequest request)
    {
        var blog = await _blogRead.GetByIdAsync(request.Id);
        if (blog == null)
        {
            return Response<DeleteBlogCommandResponse>.Fail("Blog category bulunamadı");
        }
        await _blogWrite.RemoveAsync(request.Id);
        await _blogWrite.SaveAsync();
        return Response<DeleteBlogCommandResponse>.Success($"{blog.Title} silindi");
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

    private async Task<BlogImage> UpdateImage(IFormFile image, string userId)
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