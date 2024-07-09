using BetelgeuseAPI.Application.Repositories.Course.CourseType;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseType;

public class CourseTypeWriteRepository:WriteRepository<IdentityContext,Domain.Entities.Course.Content.CourseType>, ICourseTypeWriteRepository
{
    public CourseTypeWriteRepository(IdentityContext context) : base(context)
    {
    }
}