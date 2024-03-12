using BetelgeuseAPI.Application.DTOs.Response.Category;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Category.GetEBookCategory.GetEBookCategory;

public class GetEBookCategoryCommandResponse:ResponseMessageAndSucceeded
{
    public List<GetAllCategoryResponseDto> Data { get; set; }
}