using BetelgeuseAPI.Application.Features.Commands.Category.DeleteCategory;
using BetelgeuseAPI.Application.Features.Commands.Category.UploadCategory;
using BetelgeuseAPI.Application.Features.Queries.Category.GetAllCategory;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Abstractions.Services;

public interface ICategoryService
{
    Task<Response<UploadCategoryCommandResponse>> UploadCategoryAsync(UploadCategoryCommandRequest request);
    Task<Response<GetParentCategoryCommandResponse>> GetAllCategoryAsync();

    Task<Response<DeleteCategoryCommandResponse>> DeleteCategoryAsync(DeleteCategoryCommandRequest request);
}