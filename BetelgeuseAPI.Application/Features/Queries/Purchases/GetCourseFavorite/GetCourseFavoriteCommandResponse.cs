using BetelgeuseAPI.Application.DTOs.Response.Purchases;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Purchases.GetCourseFavorite;

public class GetCourseFavoriteCommandResponse:ResponseMessageAndSucceeded
{
    public List<GetCourseFavoriteDto> Data {get; set; }
}