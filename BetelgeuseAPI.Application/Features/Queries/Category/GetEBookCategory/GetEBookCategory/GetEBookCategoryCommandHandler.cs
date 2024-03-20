using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Category.GetEBookCategory.GetEBookCategory;

public class GetEBookCategoryCommandHandler:IRequestHandler<GetEBookCategoryCommandRequest,GetEBookCategoryCommandResponse>
{
    private readonly ICategoryService _categoryService;

    public GetEBookCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<GetEBookCategoryCommandResponse> Handle(GetEBookCategoryCommandRequest request, CancellationToken cancellationToken)
    {
       var result = await _categoryService.GetEBookCategoryAsync();
       return new GetEBookCategoryCommandResponse
       {
              Data = result.Data.Data,
              Succeeded = result.Succeeded,
              Message = result.Message
         };
    }
}