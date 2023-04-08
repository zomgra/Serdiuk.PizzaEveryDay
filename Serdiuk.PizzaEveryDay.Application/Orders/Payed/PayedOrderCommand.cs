using FluentResults;
using MediatR;

namespace Serdiuk.PizzaEveryDay.Application.Orders.Payed
{
    public class PayedOrderCommand : IRequest<Result<OrderDto>>
    {
        /// <summary>
        /// Order identifier
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// User identifier
        /// </summary>
        public Guid UserId { get; set; }
    }
}
