using BetelgeuseAPI.Application.Repositories.Course.CourseSubLanguage;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseSubLanguage;

public class CourseSubLanguageWriteRepository:WriteRepository<IdentityContext,Domain.Entities.CourseSubLanguage>, ICourseSubLanguageWriteRepository
{
    public CourseSubLanguageWriteRepository(IdentityContext context) : base(context)
    {
    }
}