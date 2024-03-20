using BetelgeuseAPI.Application.Repositories.Category.EBookCategory;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Category.EBookCategory;

public class EBookCategoryReadRepository:ReadRepository<IdentityContext,Domain.Entities.Category.EBookCategory>, IEBookCategoryReadRepository    
{
    public EBookCategoryReadRepository(IdentityContext context) : base(context)
    {
    }
}