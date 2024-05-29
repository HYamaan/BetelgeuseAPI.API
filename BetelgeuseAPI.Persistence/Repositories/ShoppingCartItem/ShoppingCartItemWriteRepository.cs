using BetelgeuseAPI.Application.Repositories.ShoppingCartItem;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.ShoppingCartItem;

public class ShoppingCartItemWriteRepository :
    WriteRepository<IdentityContext, Domain.Entities.Purchase.ShoppingCartItem>, IShoppingCartItemWriteRepository
{
    public ShoppingCartItemWriteRepository(IdentityContext context) : base(context)
    {
    }
}