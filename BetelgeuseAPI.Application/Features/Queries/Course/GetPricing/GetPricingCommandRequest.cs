using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetPricing;

public class GetPricingCommandRequest:IRequest<GetPricingCommandResponse>
{
    public Guid CourseId { get; set; }
}