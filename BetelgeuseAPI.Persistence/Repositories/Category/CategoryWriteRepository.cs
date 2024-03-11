using BetelgeuseAPI.Application.Repositories.Category;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Category;

public class CategoryWriteRepository : WriteRepository<IdentityContext, Domain.Entities.Category>,
    ICategoryWriteRepository
{
    public CategoryWriteRepository(IdentityContext context) : base(context)
    {
    }
}