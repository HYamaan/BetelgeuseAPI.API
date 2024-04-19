using BetelgeuseAPI.Application.Features.Commands.Purchase.PurchaseCourse;
using BetelgeuseAPI.Application.Features.Commands.Purchase.ShoppingBasket;
using BetelgeuseAPI.Application.Features.Commands.Purchase.UpdateFavoriteCourse;
using BetelgeuseAPI.Application.Features.Queries.Purchases.GetCourseFavorite;
using BetelgeuseAPI.Application.Features.Queries.Purchases.GetPurchaseCourse;
using BetelgeuseAPI.Application.Features.Queries.Purchases.GetShoppingCart;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Abstractions.Services;

public interface IPurchaseService
{
    Task<Response<PurchaseCourseCommandResponse>> PurchaseCourse(PurchaseCourseCommandRequest request);
    Task<Response<ShoppingBasketCommandResponse>> UpdateToShoppingCart(ShoppingBasketCommandRequest request);
    Task<Response<UpdateFavoriteCourseCommandResponse>> UpdateFavoriteCourse(UpdateFavoriteCourseCommandRequest request);

    Task<Response<GetShoppingCartCommandResponse>> GetShoppingCart();
    Task<Response<GetCourseFavoriteCommandResponse>> GetCourseFavorite();
    Task<Response<GetPurchaseCourseCommandResponse>> GetPurchaseCourse();
}