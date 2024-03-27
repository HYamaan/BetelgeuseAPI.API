using BetelgeuseAPI.Application.DTOs.Request.Course;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetPricing;

public class GetPricingCommandResponse:ResponseMessageAndSucceeded
{
    public int Price { get; set; }
    public bool? IsFree { get; set; }

    public List<NewCoursePricingPlanRequestDto>? PricingPlan { get; set; }
}