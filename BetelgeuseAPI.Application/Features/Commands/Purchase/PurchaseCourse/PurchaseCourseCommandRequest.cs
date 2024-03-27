using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Purchase.PurchaseCourse;

public class PurchaseCourseCommandRequest:IRequest<PurchaseCourseCommandResponse>
{
    public Guid CourseId { get; set; }
}