using BetelgeuseAPI.Application.Repositories.Course.CourseNewPricing;
using BetelgeuseAPI.Domain.Entities.Course.Pricing;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseNewPricing;

public class CourseNewPricingWriteRepository:WriteRepository<IdentityContext,NewCoursePricingPlan>,ICourseNewPricingWriteRepository
{
    public CourseNewPricingWriteRepository(IdentityContext context) : base(context)
    {
    }
}