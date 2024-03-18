using BetelgeuseAPI.Application.Repositories.Category.CourseCategory;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Category.CourseCategory;

public class CourseCategoryWriteRepository : WriteRepository<IdentityContext, Domain.Entities.Category.CourseCategory>,
    ICourseCategoryWriteRepository
{
    public CourseCategoryWriteRepository(IdentityContext context) : base(context)
    {
    }
}