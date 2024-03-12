using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.DTOs.Response.Category;
using BetelgeuseAPI.Application.Features.Commands.Category.BlogCategory.UploadBlogCategory;
using BetelgeuseAPI.Application.Features.Commands.Category.CourseCategory.UploadCourseCategory;
using BetelgeuseAPI.Application.Features.Commands.Category.DeleteCategory;
using BetelgeuseAPI.Application.Features.Commands.Category.EBookCategory.UploadEBookCategory;
using BetelgeuseAPI.Application.Features.Queries.Category.BlogCategory.GetBlogCategory;
using BetelgeuseAPI.Application.Features.Queries.Category.CourseCategory.GetCourseCategory;
using BetelgeuseAPI.Application.Features.Queries.Category.GetAllCategory;
using BetelgeuseAPI.Application.Features.Queries.Category.GetEBookCategory.GetEBookCategory;
using BetelgeuseAPI.Application.Repositories.Category;
using BetelgeuseAPI.Application.Repositories.Category.BlogCategory;
using BetelgeuseAPI.Application.Repositories.Category.CourseCategory;
using BetelgeuseAPI.Application.Repositories.Category.EBookCategory;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetelgeuseAPI.Persistence.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryReadRepository _categoryReadRepository;
    private readonly ICategoryWriteRepository _categoryWriteRepository;
    private readonly IBlogCategoryWriteRepository _blogCategoryWriteRepository;
    private readonly IBlogCategoryReadRepository _blogCategoryReadRepository;
    private readonly ICourseCategoryWriteRepository _courseCategoryWriteRepository;
    private readonly ICourseCategoryReadRepository _courseCategoryReadRepository;
    private readonly IEBookCategoryWriteRepository _eBookCategoryWriteRepository;
    private readonly IEBookCategoryReadRepository _eBookCategoryReadRepository;

    public CategoryService(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository, IBlogCategoryWriteRepository blogCategoryWriteRepository, IBlogCategoryReadRepository blogCategoryReadRepository, ICourseCategoryWriteRepository courseCategoryWriteRepository, ICourseCategoryReadRepository courseCategoryReadRepository, IEBookCategoryWriteRepository eBookCategoryWriteRepository, IEBookCategoryReadRepository eBookCategoryReadRepository)
    {
        _categoryWriteRepository = categoryWriteRepository;
        _categoryReadRepository = categoryReadRepository;
        _blogCategoryWriteRepository = blogCategoryWriteRepository;
        _blogCategoryReadRepository = blogCategoryReadRepository;
        _courseCategoryWriteRepository = courseCategoryWriteRepository;
        _courseCategoryReadRepository = courseCategoryReadRepository;
        _eBookCategoryWriteRepository = eBookCategoryWriteRepository;
        _eBookCategoryReadRepository = eBookCategoryReadRepository;
    }

    public async Task<Response<GetParentCategoryCommandResponse>> GetAllCategoryAsync()
    {
        try
        {
            var allCategories = await _categoryReadRepository.GetWhere(x => x.Published).Select(ux => new GetAllCategoryResponseDto()
            {
                CategoryID = ux.Id,
                Name = ux.Name,
                ParentCategoryID = ux.ParentCategoryID,
                ParentCategoryName = ux.ParentCategory.Name
            }).ToListAsync();


            return Response<GetParentCategoryCommandResponse>.Success(new GetParentCategoryCommandResponse()
            {
                Data = allCategories
            }, "Categoryler başarılı bir şekilde getirildi");

        }
        catch (Exception ex)
        {
            return Response<GetParentCategoryCommandResponse>.Fail($"Kategori yüklenirken bir hata oluştu: {ex.Message}");
        }
    }
    public async Task<Response<GetBlogCategoryCommandResponse>> GetBlogCategoryAsync()
    {
        try
        {
            var allCategories = await _blogCategoryReadRepository.GetWhere(x => x.Published).Select(ux => new GetAllCategoryResponseDto()
            {
                CategoryID = ux.Id,
                Name = ux.Name,
                ParentCategoryID = ux.ParentCategoryID,
                ParentCategoryName = ux.ParentCategory.Name
            }).ToListAsync();


            return Response<GetBlogCategoryCommandResponse>.Success(new GetBlogCategoryCommandResponse()
            {
                Data = allCategories
            }, "Categoryler başarılı bir şekilde getirildi");

        }
        catch (Exception ex)
        {
            return Response<GetBlogCategoryCommandResponse>.Fail($"Kategori yüklenirken bir hata oluştu: {ex.Message}");
        }
    }
    public async Task<Response<GetCourseCategoryCommandResponse>> GetCourseCategoryAsync()
    {
        try
        {
            var allCategories = await _courseCategoryReadRepository.GetWhere(x => x.Published).Select(ux => new GetAllCategoryResponseDto()
            {
                CategoryID = ux.Id,
                Name = ux.Name,
                ParentCategoryID = ux.ParentCategoryID,
                ParentCategoryName = ux.ParentCategory.Name
            }).ToListAsync();


            return Response<GetCourseCategoryCommandResponse>.Success(new GetCourseCategoryCommandResponse()
            {
                Data = allCategories
            }, "Categoryler başarılı bir şekilde getirildi");

        }
        catch (Exception ex)
        {
            return Response<GetCourseCategoryCommandResponse>.Fail($"Kategori yüklenirken bir hata oluştu: {ex.Message}");
        }
    }
    public async Task<Response<GetEBookCategoryCommandResponse>> GetEBookCategoryAsync()
    {
        try
        {
            var allCategories = await _eBookCategoryReadRepository.GetWhere(x => x.Published).Select(ux => new GetAllCategoryResponseDto()
            {
                CategoryID = ux.Id,
                Name = ux.Name,
                ParentCategoryID = ux.ParentCategoryID,
                ParentCategoryName = ux.ParentCategory.Name
            }).ToListAsync();


            return Response<GetEBookCategoryCommandResponse>.Success(new GetEBookCategoryCommandResponse()
            {
                Data = allCategories
            }, "Categoryler başarılı bir şekilde getirildi");

        }
        catch (Exception ex)
        {
            return Response<GetEBookCategoryCommandResponse>.Fail($"Kategori yüklenirken bir hata oluştu: {ex.Message}");
        }
    }


    public async Task<Response<UploadBlogCategoryCommandResponse>> UploadBlogCategoryAsync(UploadBlogCategoryCommandRequest request)
    {
        try
        {
            BlogCategory newCategory = new BlogCategory
            {
                Name = request.CategoryName,
                Published = request.Published,
                ParentCategoryID = request.ParentCategoryID
            };

            await _blogCategoryWriteRepository.AddAsync(newCategory);
            await _blogCategoryWriteRepository.SaveAsync();

            return Response<UploadBlogCategoryCommandResponse>.Success("Blog kategori başarıyla yüklendi.");
        }
        catch (Exception ex)
        {
            return Response<UploadBlogCategoryCommandResponse>.Fail($"Blog kategori yüklenirken bir hata oluştu: {ex.Message}");
        }
    }
    public async Task<Response<UploadCourseCategoryCommandResponse>> UploadCourseCategoryAsync(UploadCourseCategoryCommandRequest request)
    {
        try
        {
            CourseCategory newCategory = new CourseCategory()
            {
                Name = request.CategoryName,
                Published = request.Published,
                ParentCategoryID = request.ParentCategoryID
            };

            await _courseCategoryWriteRepository.AddAsync(newCategory);
            await _blogCategoryWriteRepository.SaveAsync();

            return Response<UploadCourseCategoryCommandResponse>.Success("Course kategori başarıyla yüklendi.");
        }
        catch (Exception ex)
        {
            return Response<UploadCourseCategoryCommandResponse>.Fail($"Course kategori yüklenirken bir hata oluştu: {ex.Message}");
        }
    }
    public async Task<Response<UploadEBookCategoryCommandResponse>> UploadEBookCategoryAsync(UploadEBookCategoryCommandRequest request)
    {
        try
        {
            EBookCategory newCategory = new EBookCategory
            {
                Name = request.CategoryName,
                Published = request.Published,
                ParentCategoryID = request.ParentCategoryID
            };

            await _eBookCategoryWriteRepository.AddAsync(newCategory);
            await _eBookCategoryWriteRepository.SaveAsync();

            return Response<UploadEBookCategoryCommandResponse>.Success("Ebook kategori başarıyla yüklendi.");
        }
        catch (Exception ex)
        {
            return Response<UploadEBookCategoryCommandResponse>.Fail($"Ebook kategori yüklenirken bir hata oluştu: {ex.Message}");
        }
    }

    public async Task<Response<DeleteCategoryCommandResponse>> DeleteCategoryAsync(DeleteCategoryCommandRequest request)
    {
        var categoryToDelete = await _categoryReadRepository.GetWhere(ux => ux.Id == request.Id).Include(ux => ux.ChildCategories).FirstOrDefaultAsync();
        if (categoryToDelete == null)
        {
            return Response<DeleteCategoryCommandResponse>.Fail($"ID'si {request.Id} olan kategori bulunamadı.");
        }
        if (categoryToDelete.ChildCategories != null && categoryToDelete.ChildCategories.Any())
        {
            return Response<DeleteCategoryCommandResponse>.Fail("Bu kategorinin altında başka kategoriler bulunmaktadır. Lütfen önce alt kategorileri silin.");
        }


        await _categoryWriteRepository.RemoveAsync(categoryToDelete.Id.ToString());
        await _categoryWriteRepository.SaveAsync();

        return Response<DeleteCategoryCommandResponse>.Success($"{request.Id} Kategori başarıyla silindi");
    }
}