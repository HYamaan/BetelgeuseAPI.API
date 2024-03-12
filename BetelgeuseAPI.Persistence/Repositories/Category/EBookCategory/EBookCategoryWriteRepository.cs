using BetelgeuseAPI.Application.Repositories.Category.EBookCategory;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Category.EBookCategory;

public class EBookCategoryWriteRepository:WriteRepository<IdentityContext,Domain.Entities.EBookCategory>, IEBookCategoryWriteRepository
{
    public EBookCategoryWriteRepository(IdentityContext context) : base(context)
    {
    }
}