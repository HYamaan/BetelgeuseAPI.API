using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Category.CourseCategory.GetCourseCategory;

public class GetCourseCategoryCommandHandler:IRequestHandler<GetCourseCategoryCommandRequest,GetCourseCategoryCommandResponse>
{
    private readonly ICategoryService _categoryService;

    public GetCourseCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<GetCourseCategoryCommandResponse> Handle(GetCourseCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _categoryService.GetCourseCategoryAsync();
        return new GetCourseCategoryCommandResponse
        {
            Data = result.Data.Data,
            Succeeded = result.Succeeded,
            Message = result.Message
        };
    }
}