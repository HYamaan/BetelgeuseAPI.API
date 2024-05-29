using BetelgeuseAPI.Application.Repositories.ShoppingCartItem;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.ShoppingCartItem;

public class ShoppingCartItemReadRepository :
    ReadRepository<IdentityContext, Domain.Entities.Purchase.ShoppingCartItem>, IShoppingCartItemReadRepository
{
    public ShoppingCartItemReadRepository(IdentityContext context) : base(context)
    {
    }
}