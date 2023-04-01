using Serdiuk.PizzaEveryDay.Domain;
using Serdiuk.PizzaEveryDay.Domain.Enums;

namespace Serdiuk.PizzaEveryDay.Application.Orders
{
    public class OrderDto
    {
        /// <summary>
        /// Order identifier
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Delivery street
        /// </summary>
        public string StreetToDelivery { get; set; }
        /// <summary>
        /// Final Cost with promocode
        /// </summary>
        public decimal FinalCost { get; set; }
        /// <summary>
        /// Used promocode
        /// </summary>
        public Promocode? Promocode { get; set; }
        /// <summary>
        /// Products in order
        /// </summary>
        public ICollection<Product> Products { get; set; }
        /// <summary>
        /// Status of order
        /// </summary>
        public OrderStatus Status { get; set; }
    }
}
