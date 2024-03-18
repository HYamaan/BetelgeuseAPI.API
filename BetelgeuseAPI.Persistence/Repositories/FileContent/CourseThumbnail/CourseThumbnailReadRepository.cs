using BetelgeuseAPI.Application.Repositories.FileContent.CourseThumbnail;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.FileContent.CourseThumbnail;

public class CourseThumbnailReadRepository : ReadRepository<IdentityContext, Domain.Entities.File.CourseThumbnail>,
    ICourseThumbnailReadRepository
{
    public CourseThumbnailReadRepository(IdentityContext context) : base(context)
    {
    }
}