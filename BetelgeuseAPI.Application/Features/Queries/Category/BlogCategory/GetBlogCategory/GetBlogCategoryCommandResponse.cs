using BetelgeuseAPI.Application.DTOs.Response.Category;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Category.BlogCategory.GetBlogCategory;

public class GetBlogCategoryCommandResponse:ResponseMessageAndSucceeded
{
    public List<GetCategories> Data { get; set; }
}