using BetelgeuseAPI.Application.Repositories.FileContent.CourseCoverImage;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.FileContent.CourseCoverImage;

public class CourseCoverImageReadRepository:ReadRepository<IdentityContext,Domain.Entities.File.CourseCoverImage>, ICourseCoverImageReadRepository
{
    public CourseCoverImageReadRepository(IdentityContext context) : base(context)
    {
    }
}