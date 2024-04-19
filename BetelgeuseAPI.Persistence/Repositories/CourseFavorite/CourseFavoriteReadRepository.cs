using BetelgeuseAPI.Application.Repositories.CourseFavorite;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.CourseFavorite;

public class CourseFavoriteReadRepository : ReadRepository<IdentityContext,Domain.Entities.Purchase.CourseFavorite>, ICourseFavoriteReadRepository
{
    public CourseFavoriteReadRepository(IdentityContext context) : base(context)
    {
    }
}