using BetelgeuseAPI.Application.Repositories.Purchase;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.Purchase;

public class PurchaseReadRepository:ReadRepository<IdentityContext,Domain.Entities.Purchase.Purchase>, IPurchaseReadRepository
{
    public PurchaseReadRepository(IdentityContext context) : base(context)
    {
    }
}