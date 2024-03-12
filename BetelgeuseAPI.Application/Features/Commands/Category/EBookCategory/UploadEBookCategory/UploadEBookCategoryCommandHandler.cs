using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Category.EBookCategory.UploadEBookCategory;

public class UploadEBookCategoryCommandHandler : IRequestHandler<UploadEBookCategoryCommandRequest, UploadEBookCategoryCommandResponse>

{
    private readonly ICategoryService _categoryService;

    public UploadEBookCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<UploadEBookCategoryCommandResponse> Handle(UploadEBookCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _categoryService.UploadEBookCategoryAsync(request);
        return new UploadEBookCategoryCommandResponse()
        {
            Succeeded = result.Succeeded,
            Message = result.Message
        };
    }
}