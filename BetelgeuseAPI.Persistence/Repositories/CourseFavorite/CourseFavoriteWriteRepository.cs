using BetelgeuseAPI.Application.Repositories.CourseFavorite;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.CourseFavorite;

public class CourseFavoriteWriteRepository: WriteRepository<IdentityContext,Domain.Entities.Purchase.CourseFavorite>, ICourseFavoriteWriteRepository
{
    public CourseFavoriteWriteRepository(IdentityContext context) : base(context)
    {
    }
}