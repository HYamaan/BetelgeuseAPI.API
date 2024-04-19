using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Purchases.GetShoppingCart;

public class GetShoppingCartCommandHandler:IRequestHandler<GetShoppingCartCommandRequest, GetShoppingCartCommandResponse>
{
    public IPurchaseService _purchaseService;

    public GetShoppingCartCommandHandler(IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }

    public async Task<GetShoppingCartCommandResponse> Handle(GetShoppingCartCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _purchaseService.GetShoppingCart();
        return new GetShoppingCartCommandResponse()
        {
            Data = result.Data?.Data,
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}