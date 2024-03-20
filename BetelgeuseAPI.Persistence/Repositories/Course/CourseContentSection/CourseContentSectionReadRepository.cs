using BetelgeuseAPI.Application.Repositories.Course.CourseContent;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseContent;

public class CourseContentSectionReadRepository:ReadRepository<IdentityContext,Domain.Entities.Course.Content.CourseSections>,ICourseContentSectionReadRepository
{
    public CourseContentSectionReadRepository(IdentityContext context) : base(context)
    {
    }
}