using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Upload.DeleteNewCoursePricing;

public class DeleteNewCoursePricingCommandRequest: IRequest<DeleteNewCoursePricingCommandResponse>
{
    public Guid PricingId { get; set; }
}