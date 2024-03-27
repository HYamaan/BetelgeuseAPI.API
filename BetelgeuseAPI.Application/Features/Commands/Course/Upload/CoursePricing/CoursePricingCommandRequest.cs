using BetelgeuseAPI.Application.DTOs.Request.Course;
using BetelgeuseAPI.Domain.Entities.Course;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Upload.CoursePricing;

public class CoursePricingCommandRequest : IRequest<CoursePricingCommandResponse>
{
    public Guid CourseId { get; set; }
    public int Price { get; set; }
    public bool? IsFree { get; set; }

    public List<NewCoursePricingPlanRequestDto>? NewCoursePricingPlanRequestDto { get; set; }
}