using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serdiuk.PizzaEveryDay.Application.Promocodes.GetDiscountAmount;
using Serdiuk.PizzaEveryDay.WebApi.Controllers.Base;

namespace Serdiuk.PizzaEveryDay.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/promocode")]
    public class PromocodeController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetPromocodeDiscountAmount([FromQuery] GetDiscountAmountQueryDto request, CancellationToken cancellationToken)
        {
            var query = new GetDiscountAmountQuery() { Code = request.Code, UserId = UserId};
            var result = await Mediator.Send(query);
            if (result.IsFailed)
                return BadRequest(result.Reasons.Select(m => m.Message));

            return Ok(result.Value);
        }
    }
}
