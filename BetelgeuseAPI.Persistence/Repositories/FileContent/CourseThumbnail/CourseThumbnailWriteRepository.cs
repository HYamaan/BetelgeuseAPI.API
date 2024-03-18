using BetelgeuseAPI.Application.Repositories.FileContent.CourseThumbnail;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.FileContent.CourseThumbnail;

public class CourseThumbnailWriteRepository:WriteRepository<IdentityContext,Domain.Entities.File.CourseThumbnail>, ICourseThumbnailWriteRepository
{
    public CourseThumbnailWriteRepository(IdentityContext context) : base(context)
    {
    }
}