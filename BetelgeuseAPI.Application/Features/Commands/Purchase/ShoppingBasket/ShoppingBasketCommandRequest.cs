using BetelgeuseAPI.Application.DTOs.Request.Purchase;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Purchase.ShoppingBasket;

public class ShoppingBasketCommandRequest : IRequest<ShoppingBasketCommandResponse>
{
    public Guid CourseId { get; set; }
}