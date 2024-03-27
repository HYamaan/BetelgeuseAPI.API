using BetelgeuseAPI.Application.Repositories.Purchase;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.Purchase;

public class PurchaseWriteRepository:WriteRepository<IdentityContext,Domain.Entities.Purchase.Purchase>, IPurchaseWriteRepository
{
    public PurchaseWriteRepository(IdentityContext context) : base(context)
    {
    }
}