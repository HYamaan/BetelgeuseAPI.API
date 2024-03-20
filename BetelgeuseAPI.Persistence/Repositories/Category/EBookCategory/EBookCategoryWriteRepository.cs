using BetelgeuseAPI.Application.Repositories.Category.EBookCategory;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Category.EBookCategory;

public class EBookCategoryWriteRepository:WriteRepository<IdentityContext,Domain.Entities.Category.EBookCategory>, IEBookCategoryWriteRepository
{
    public EBookCategoryWriteRepository(IdentityContext context) : base(context)
    {
    }
}