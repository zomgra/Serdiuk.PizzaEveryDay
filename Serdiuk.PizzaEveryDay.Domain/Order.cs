using Serdiuk.PizzaEveryDay.Domain.Enums;

namespace Serdiuk.PizzaEveryDay.Domain
{
    public class Order
    {
        public Order(Guid userId, string streetToDelivery)
        {
            UserId = userId;
            StreetToDelivery = streetToDelivery;

            //Use status randomization to test status filtering
            Array values = Enum.GetValues(typeof(OrderStatus));
            Random random = new Random();
            OrderStatus status = (OrderStatus)values.GetValue(random.Next(values.Length));
            Status = status;
            //Status = OrderStatus.Open;
        }

        public Order(int orderId, Guid userId, string streetToDelivery, string streetToBake, OrderStatus status)
        {
            OrderId = orderId;
            UserId = userId;
            StreetToDelivery = streetToDelivery;
            StreetToBake = streetToBake;
            Status = status;
        }

        /// <summary>
        /// Order identifier
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// User indentifier
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Street to delivery
        /// </summary>
        public string StreetToDelivery { get; set; }
        /// <summary>
        /// Bake street
        /// </summary>
        public string? StreetToBake { get; set; }
        /// <summary>
        /// Total cost all product
        /// </summary>
        public decimal TotalCost
        {
            get 
            {
                return Products.Sum(s => s.Cost);
            }
        }
        /// <summary>
        /// Final Cost with promocode
        /// </summary>
        public decimal FinalCost
        {
            get
            {
                return Promocode == null ? TotalCost : TotalCost - Promocode.DiscountAmount;
            }
        }
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
