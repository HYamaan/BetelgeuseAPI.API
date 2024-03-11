using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.DTOs.Response.Category;
using BetelgeuseAPI.Application.Features.Commands.Category.DeleteCategory;
using BetelgeuseAPI.Application.Features.Commands.Category.UploadCategory;
using BetelgeuseAPI.Application.Features.Queries.Category.GetAllCategory;
using BetelgeuseAPI.Application.Repositories.Category;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetelgeuseAPI.Persistence.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryReadRepository _categoryReadRepository;
    private readonly ICategoryWriteRepository _categoryWriteRepository;

    public CategoryService(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
    {
        _categoryWriteRepository = categoryWriteRepository;
        _categoryReadRepository = categoryReadRepository;
    }

    public async Task<Response<UploadCategoryCommandResponse>> UploadCategoryAsync(UploadCategoryCommandRequest request)
    {
        try
        {
            Category newCategory = new Category
            {
                Name = request.CategoryName,
                Published = request.Published,
                ParentCategoryID = request.ParentCategoryID
            };

            await _categoryWriteRepository.AddAsync(newCategory);
            await _categoryWriteRepository.SaveAsync();

            return Response<UploadCategoryCommandResponse>.Success("Kategori başarıyla yüklendi.");
        }
        catch (Exception ex)
        {
            return Response<UploadCategoryCommandResponse>.Fail($"Kategori yüklenirken bir hata oluştu: {ex.Message}");
        }
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

    public async Task<Response<DeleteCategoryCommandResponse>> DeleteCategoryAsync(DeleteCategoryCommandRequest request)
    {
        var categoryToDelete = await _categoryReadRepository.GetWhere(ux=> ux.Id == request.Id).Include(ux=>ux.ChildCategories).FirstOrDefaultAsync();
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