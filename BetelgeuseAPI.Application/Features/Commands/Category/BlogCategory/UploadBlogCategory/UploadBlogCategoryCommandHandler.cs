using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Category.BlogCategory.UploadBlogCategory;

public class UploadBlogCategoryCommandHandler:IRequestHandler<UploadBlogCategoryCommandRequest, UploadBlogCategoryCommandResponse>
{
    private readonly ICategoryService _categoryService;

    public UploadBlogCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<UploadBlogCategoryCommandResponse> Handle(UploadBlogCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _categoryService.UploadBlogCategoryAsync(request);
        return new UploadBlogCategoryCommandResponse()
        {
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}