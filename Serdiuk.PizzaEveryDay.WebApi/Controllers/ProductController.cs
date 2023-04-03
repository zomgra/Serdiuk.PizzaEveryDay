using Microsoft.AspNetCore.Mvc;
using Serdiuk.PizzaEveryDay.Application.Products.GetAll;
using Serdiuk.PizzaEveryDay.WebApi.Controllers.Base;

namespace Serdiuk.PizzaEveryDay.WebApi.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
                var query = new GetAllProductQuery();
            var result = await Mediator.Send(query);
            if (result.IsFailed)
                return BadRequest(result.Reasons.Select(m => m.Message));

            return Ok(result.Value);
        }
    }
}
