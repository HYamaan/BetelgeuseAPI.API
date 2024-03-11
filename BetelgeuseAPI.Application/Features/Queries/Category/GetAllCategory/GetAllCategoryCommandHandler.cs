using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Category.GetAllCategory;

public class GetParentCategoryCommandHandler:IRequestHandler<GetParentCategoryCommandRequest,GetParentCategoryCommandResponse>
{
    private readonly ICategoryService _categoryService;

    public GetParentCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<GetParentCategoryCommandResponse> Handle(GetParentCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _categoryService.GetAllCategoryAsync();
        return new GetParentCategoryCommandResponse()
        {
            Data = result.Data.Data,
            Succeeded = result.Succeeded,
            Message = result.Message
        } ;
    }
}