using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Category.UploadCategory;

public class UploadCategoryCommandHandler : IRequestHandler<UploadCategoryCommandRequest, UploadCategoryCommandResponse>
{
    private readonly ICategoryService _categoryService;

    public UploadCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<UploadCategoryCommandResponse> Handle(UploadCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _categoryService.UploadCategoryAsync(request);
        return new UploadCategoryCommandResponse()
        {
            Message = response.Message,
            Succeeded = response.Succeeded
        };
    }
}