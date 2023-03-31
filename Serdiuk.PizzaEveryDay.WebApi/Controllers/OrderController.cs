using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serdiuk.PizzaEveryDay.Application.Orders.Create;
using Serdiuk.PizzaEveryDay.Application.Orders.GetOrdersByUserId;
using Serdiuk.PizzaEveryDay.WebApi.Controllers.Base;

namespace Serdiuk.PizzaEveryDay.WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/product/orders")]
    public class OrderController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetOrdersByUserId([FromQuery] GetOrdersByUserIdQueryDto request, CancellationToken cancellationToken)
        {
            var query = new GetOrdersByUserIdQuery() { Status = request.Status, UserId = UserId };
            var result = await Mediator.Send(query, cancellationToken);

            if (result.IsFailed)
                return BadRequest(result.Reasons.Select(result => result.Message));

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(CreateOrderCommandDto request, CancellationToken cancellationToken)
        {
            var command = new CreateOrderCommand { ProductsId = request.ProductsId, PromoCode = request.PromoCode, StreetToDelivery = request.StreetToDelivery, UserId = UserId };
            var result = await Mediator.Send(command, cancellationToken);
            if(result.IsFailed)
                return BadRequest(result.Reasons.Select(result => result.Message));

            return Ok(result.Value);
        }
    }
}
