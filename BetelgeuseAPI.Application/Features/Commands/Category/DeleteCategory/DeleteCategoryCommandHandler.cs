using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Category.DeleteCategory;

public class DeleteCategoryCommandHandler:IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
{
    private readonly ICategoryService _categoryService;

    public DeleteCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var result= await _categoryService.DeleteCategoryAsync(request);
        return new DeleteCategoryCommandResponse()
        {
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}