using BetelgeuseAPI.Application.Repositories.Category.CourseCategory;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Category.CourseCategory;

public class CourseCategoryReadRepository : ReadRepository<IdentityContext, Domain.Entities.Category.CourseCategory>,
    ICourseCategoryReadRepository
{
    public CourseCategoryReadRepository(IdentityContext context) : base(context)
    {
    }
}