using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Blog.BlogCategory.AddBlogCategory;

public class AddBlogCategoryCommandHandler : IRequestHandler<AddBlogCategoryCommandRequest, AddBlogCategoryCommandResponse>
{
    private readonly IBlogService _blogService;

    public AddBlogCategoryCommandHandler(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task<AddBlogCategoryCommandResponse> Handle(AddBlogCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _blogService.AddBlogCategory(request);
        return new AddBlogCategoryCommandResponse()
        {
            Succeeded = response.Succeeded,
            Message = response.Message
        };
    }
}
