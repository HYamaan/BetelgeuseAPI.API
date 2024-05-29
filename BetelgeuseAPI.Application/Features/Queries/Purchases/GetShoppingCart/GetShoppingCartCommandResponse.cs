using BetelgeuseAPI.Application.DTOs.Response.Purchases;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Purchases.GetShoppingCart;

public class GetShoppingCartCommandResponse:ResponseMessageAndSucceeded
{
    public List<ShoppingCartDto> Data { get; set; }
}