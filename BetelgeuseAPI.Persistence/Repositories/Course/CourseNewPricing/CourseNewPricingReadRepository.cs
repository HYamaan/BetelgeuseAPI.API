using BetelgeuseAPI.Domain.Entities.Course.Pricing;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseNewPricing;

public class CourseNewPricingReadRepository:ReadRepository<IdentityContext,NewCoursePricingPlan>,ICourseNewPricingReadRepository
{
    public CourseNewPricingReadRepository(IdentityContext context) : base(context)
    {
    }
}