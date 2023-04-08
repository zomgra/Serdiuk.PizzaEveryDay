using FluentResults;
using MediatR;

namespace Serdiuk.PizzaEveryDay.Application.Orders.Cancel
{
    public class CancelOrderCommand : IRequest<Result<OrderDto>>
    {
        /// <summary>
        /// Order Identifier
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// User identifier
        /// </summary>
        public Guid UserId { get; set; }
    }
}
