using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serdiuk.PizzaEveryDay.Application.Orders.Cancel;
using Serdiuk.PizzaEveryDay.Application.Orders.Create;
using Serdiuk.PizzaEveryDay.Application.Orders.Edit;
using Serdiuk.PizzaEveryDay.Application.Orders.GetOrdersByUserId;
using Serdiuk.PizzaEveryDay.Application.Orders.Payed;
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
        [HttpPut]
        public async Task<IActionResult> PayForOrder(PayedOrderCommandDto request, CancellationToken cancellationToken)
        {
            var command = new PayedOrderCommand() { OrderId = request.OrderId, UserId = UserId };
            var result = await Mediator.Send(command, cancellationToken);

            if (result.IsFailed)
                return BadRequest(result.Reasons.Select(result => result.Message));

            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> CancelOrder(CancelOrderCommandDto request, CancellationToken cancellationToken)
        {
            var command = new CancelOrderCommand() { OrderId = request.OrderId, UserId = UserId };
            var result = await Mediator.Send(command, cancellationToken);

            if (result.IsFailed)
                return BadRequest(result.Reasons.Select(result => result.Message));

            return Ok();
        }
        [HttpPut("edit")]
        public async Task<IActionResult> EditOrderAsync(EditOrderCommandDto request, CancellationToken cancellationToken)
        {
            var command = new EditOrderCommand() { Street = request.Street, OrderId = request.OrderId, UserId = UserId };
            var result = await Mediator.Send(command, cancellationToken);

            if (result.IsFailed)
                return BadRequest(result.Reasons.Select(result => result.Message));

            return Ok(result.Value);
        }
        [HttpPost("delivery")]
        [Authorize(Roles = "Manager")]
        //TODO : Create an Admin panel to manage the delivery of orders
        public async Task<IActionResult> DeliveryOrder()
        {
            return Ok();
        }
    }
}
