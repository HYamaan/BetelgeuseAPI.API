using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Category.CourseCategory.UploadCourseCategory;

public class UploadCourseCategoryCommandHandler:IRequestHandler<UploadCourseCategoryCommandRequest,UploadCourseCategoryCommandResponse>
{
    private readonly ICategoryService _categoryService;

    public UploadCourseCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<UploadCourseCategoryCommandResponse> Handle(UploadCourseCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _categoryService.UploadCourseCategoryAsync(request);

        return new UploadCourseCategoryCommandResponse()
        {
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}