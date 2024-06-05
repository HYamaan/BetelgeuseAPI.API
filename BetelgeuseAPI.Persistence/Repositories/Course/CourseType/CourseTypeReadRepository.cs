using BetelgeuseAPI.Application.Repositories.Course.CourseType;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseType;

public class CourseTypeReadRepository:ReadRepository<IdentityContext, Domain.Entities.Course.Content.CourseType>, ICourseTypeReadRepository
{
    public CourseTypeReadRepository(IdentityContext context) : base(context)
    {
    }
}