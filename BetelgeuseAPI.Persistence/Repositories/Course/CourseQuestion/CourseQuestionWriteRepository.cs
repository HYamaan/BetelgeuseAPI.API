using BetelgeuseAPI.Application.Repositories.Course.CourseQuestion;
using BetelgeuseAPI.Domain.Entities.Course.Content.Quiz;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseQuestion;

public class CourseQuestionWriteRepository:WriteRepository<IdentityContext,CourseQuestions>,ICourseQuestionWriteRepository
{
    public CourseQuestionWriteRepository(IdentityContext context) : base(context)
    {
    }
}