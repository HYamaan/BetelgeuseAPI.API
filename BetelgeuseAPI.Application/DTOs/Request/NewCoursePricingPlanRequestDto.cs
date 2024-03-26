using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Domain.Entities.Course;
using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Application.DTOs.Request;

public class NewCoursePricingPlanRequestDto
{
    public string Title { get; set; }
    public int Discount { get; set; }
    public int Capacity { get; set; }
    public int Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Languages Language { get; set; }
}