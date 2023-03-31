using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Serdiuk.PizzaEveryDay.WebApi.Controllers.Base
{
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        public IMediator Mediator => 
            _mediator ?? HttpContext.RequestServices.GetService<IMediator>();

        internal Guid UserId => !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
