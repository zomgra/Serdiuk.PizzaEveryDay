using FluentResults;
using MediatR;

namespace Serdiuk.PizzaEveryDay.Application.Orders.ApplyDelivery
{
    /// <summary>
    /// Command for apply delivery 
    /// </summary>
    public class ApplyDeliveryOrderCommand : IRequest<Result>
    {
        /// <summary>
        /// Identifier order
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Identifier user
        /// </summary>
        public Guid UserId { get; set; }
    }
}
