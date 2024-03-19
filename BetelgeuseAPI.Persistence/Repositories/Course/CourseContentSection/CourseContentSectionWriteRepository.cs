using BetelgeuseAPI.Application.Repositories.Course.CourseContent;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseContent;

public class CourseContentSectionWriteRepository:WriteRepository<IdentityContext,Domain.Entities.Course.Content.CourseSections>, ICourseContentSectionWriteRepository
{
    public CourseContentSectionWriteRepository(IdentityContext context) : base(context)
    {
    }
}