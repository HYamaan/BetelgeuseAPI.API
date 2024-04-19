using BetelgeuseAPI.Application.Features.Commands.Purchase.PurchaseCourse;
using BetelgeuseAPI.Application.Features.Commands.Purchase.ShoppingBasket;
using BetelgeuseAPI.Application.Features.Commands.Purchase.UpdateFavoriteCourse;
using BetelgeuseAPI.Application.Features.Queries.Purchases.GetCourseFavorite;
using BetelgeuseAPI.Application.Features.Queries.Purchases.GetPurchaseCourse;
using BetelgeuseAPI.Application.Features.Queries.Purchases.GetShoppingCart;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetelgeuseAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PurchaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PurchaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PurchaseCourse([FromBody] PurchaseCourseCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateToShoppingCart([FromQuery] ShoppingBasketCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateFavoriteCourse([FromQuery] UpdateFavoriteCourseCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetShoppingCart()
        {
            var response = await _mediator.Send(new GetShoppingCartCommandRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCourseFavorite()
        {
            var response = await _mediator.Send(new GetCourseFavoriteCommandRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPurchaseCourse()
        {
            var response = await _mediator.Send(new GetPurchaseCourseCommandRequest());
            return Ok(response);
        }

    }
}
