using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Category.BlogCategory.GetBlogCategory;

public class GetBlogCategoryCommandHandler:IRequestHandler<GetBlogCategoryCommandRequest,GetBlogCategoryCommandResponse>
{
    private readonly ICategoryService _categoryService;

    public GetBlogCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<GetBlogCategoryCommandResponse> Handle(GetBlogCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _categoryService.GetBlogCategoryAsync();
        return new GetBlogCategoryCommandResponse
        {
            Data = result.Data.Data,
            Succeeded = result.Succeeded,
            Message = result.Message
        };
    }
}