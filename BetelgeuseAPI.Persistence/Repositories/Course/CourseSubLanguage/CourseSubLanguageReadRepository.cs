using BetelgeuseAPI.Application.Repositories.Course.CourseSubLanguage;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseSubLanguage;

public class CourseSubLanguageReadRepository:ReadRepository<IdentityContext,Domain.Entities.CourseSubLanguage>, ICourseSubLanguageReadRepository
{
    public CourseSubLanguageReadRepository(IdentityContext context) : base(context)
    {
    }
}