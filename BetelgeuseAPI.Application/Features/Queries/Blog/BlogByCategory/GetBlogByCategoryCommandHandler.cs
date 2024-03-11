
using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Blog.BlogByCategory
{
    public class GetBlogByCategoryCommandHandler:IRequestHandler<GetBlogByCategoryCommandRequest,GetBlogByCategoryCommandResponse>
    {
        private readonly IBlogService _blogService;

        public GetBlogByCategoryCommandHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<GetBlogByCategoryCommandResponse> Handle(GetBlogByCategoryCommandRequest request, CancellationToken cancellationToken)
        {
           var result = await _blogService.GetBlogByCategoryAsync(request);
           return new GetBlogByCategoryCommandResponse()
           {
               Data = result.Data?.Data,
               Message = result.Message,
               Succeeded = result.Succeeded
           };
        }
    }
}
