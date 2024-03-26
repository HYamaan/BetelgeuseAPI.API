using BetelgeuseAPI.Application.Repositories.Course.CourseQuestion;
using BetelgeuseAPI.Domain.Entities.Course.Content.Quiz;
using BetelgeuseAPI.Persistence.Context;
using Microsoft.AspNetCore.Identity;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseQuestion;

public class CourseQuestionReadRepository:ReadRepository<IdentityContext,CourseQuestions>, ICourseQuestionReadRepository
{
    public CourseQuestionReadRepository(IdentityContext context) : base(context)
    {
    }
}