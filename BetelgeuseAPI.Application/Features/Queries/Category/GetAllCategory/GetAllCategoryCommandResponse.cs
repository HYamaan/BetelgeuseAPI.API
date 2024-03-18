using BetelgeuseAPI.Application.DTOs.Response.Category;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Category.GetAllCategory;

public class GetParentCategoryCommandResponse:ResponseMessageAndSucceeded
{
    public List<GetAllCategoryResponseDto> Data { get; set; }
}