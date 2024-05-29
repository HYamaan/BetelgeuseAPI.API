using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Purchase.ShoppingBasket;

public class ShoppingBasketCommandHandler : IRequestHandler<ShoppingBasketCommandRequest, ShoppingBasketCommandResponse>
{
    private readonly IPurchaseService _purchaseService;

    public ShoppingBasketCommandHandler(IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }

    public async Task<ShoppingBasketCommandResponse> Handle(ShoppingBasketCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _purchaseService.UpdateToShoppingCart(request);

        return new ShoppingBasketCommandResponse()
        {
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}