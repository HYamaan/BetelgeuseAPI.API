using BetelgeuseAPI.Application.Repositories.Category;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Category;

public class CategoryReadRepository:ReadRepository<IdentityContext,Domain.Entities.Category>,ICategoryReadRepository
{
    public CategoryReadRepository(IdentityContext context) : base(context)
    {
    }
}