using FluentResults;
using MediatR;

namespace Serdiuk.PizzaEveryDay.Application.Orders.Create
{
    /// <summary>
    /// Create order command
    /// </summary>
    public class CreateOrderCommand : IRequest<Result<OrderDto>>
    {
        /// <summary>
        /// Products id for buy
        /// </summary>
        public List<int> ProductsId { get; set; }
        /// <summary>
        /// User identifier 
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Street to delivery
        /// </summary>
        public string StreetToDelivery { get; set; }
        /// <summary>
        /// Used promocode
        /// </summary>
        public string? PromoCode { get; set; }
    }
}
