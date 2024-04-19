using BetelgeuseAPI.Application.DTOs.Response.Purchases;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Purchases.GetPurchaseCourse;

public class GetPurchaseCourseCommandResponse:ResponseMessageAndSucceeded
{
    public List<GetPurchasesCourseDto> Data { get; set; }
}