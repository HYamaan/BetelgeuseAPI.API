using BetelgeuseAPI.Application.Features.Commands.Category.BlogCategory.UploadBlogCategory;
using BetelgeuseAPI.Application.Features.Commands.Category.CourseCategory.UploadCourseCategory;
using BetelgeuseAPI.Application.Features.Commands.Category.DeleteCategory;
using BetelgeuseAPI.Application.Features.Commands.Category.EBookCategory.UploadEBookCategory;
using BetelgeuseAPI.Application.Features.Queries.Category.BlogCategory.GetBlogCategory;
using BetelgeuseAPI.Application.Features.Queries.Category.CourseCategory.GetCourseCategory;
using BetelgeuseAPI.Application.Features.Queries.Category.GetAllCategory;
using BetelgeuseAPI.Application.Features.Queries.Category.GetEBookCategory.GetEBookCategory;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Abstractions.Services;

public interface ICategoryService
{
    Task<Response<UploadBlogCategoryCommandResponse>> UploadBlogCategoryAsync(UploadBlogCategoryCommandRequest request);
    Task<Response<UploadCourseCategoryCommandResponse>> UploadCourseCategoryAsync(UploadCourseCategoryCommandRequest request);
    Task<Response<UploadEBookCategoryCommandResponse>> UploadEBookCategoryAsync(UploadEBookCategoryCommandRequest request);

    Task<Response<GetParentCategoryCommandResponse>> GetAllCategoryAsync();
    Task<Response<GetBlogCategoryCommandResponse>> GetBlogCategoryAsync();
    Task<Response<GetCourseCategoryCommandResponse>> GetCourseCategoryAsync();
    Task<Response<GetEBookCategoryCommandResponse>> GetEBookCategoryAsync();

    Task<Response<DeleteCategoryCommandResponse>> DeleteCategoryAsync(DeleteCategoryCommandRequest request);
}