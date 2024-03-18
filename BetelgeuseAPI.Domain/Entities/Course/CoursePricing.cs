using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities.Course;

public class CoursePricing:BaseEntity
{
    public int Price { get; set; }
    public bool IsFree { get; set; }

    public List<NewCoursePricingPlan>? NewCoursePricingPlan { get; set; }
}