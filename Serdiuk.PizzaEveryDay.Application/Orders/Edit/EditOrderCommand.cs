using FluentResults;
using MediatR;

namespace Serdiuk.PizzaEveryDay.Application.Orders.Edit
{
    public class EditOrderCommand : IRequest<Result<OrderDto>>
    {
        /// <summary>
        /// Order Idetifier
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// User identifier
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// New delivery street
        /// </summary>
        public string Street { get; set; }
    }
}
