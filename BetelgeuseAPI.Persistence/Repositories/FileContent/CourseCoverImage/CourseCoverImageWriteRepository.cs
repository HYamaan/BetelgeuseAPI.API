using BetelgeuseAPI.Application.Repositories.FileContent.CourseCoverImage;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.FileContent.CourseCoverImage;

public class CourseCoverImageWriteRepository:WriteRepository<IdentityContext,Domain.Entities.File.CourseCoverImage>,ICourseCoverImageWriteRepository
{
    public CourseCoverImageWriteRepository(IdentityContext context) : base(context)
    {
    }
}