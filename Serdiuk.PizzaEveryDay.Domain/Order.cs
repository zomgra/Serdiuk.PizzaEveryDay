using Serdiuk.PizzaEveryDay.Domain.Enums;
using FluentResults;

namespace Serdiuk.PizzaEveryDay.Domain
{
    public class Order
    {
        public Order(Guid userId, string streetToDelivery)
        {
            UserId = userId;
            StreetToDelivery = streetToDelivery;

            //Use status randomization to test status filtering
            //Array values = Enum.GetValues(typeof(OrderStatus));
            //Random random = new Random();
            //OrderStatus status = (OrderStatus)values.GetValue(random.Next(values.Length));
            //Status = status;
            Status = OrderStatus.Open;
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

        ///// <summary>
        ///// Flag, whether the order are paid
        ///// </summary>
        ////public bool IsPayed { get; set; } = false;

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
        /// <summary>
        /// Cancel the order
        /// </summary>
        /// <returns></returns>
        public Result Cancel()
        {
            if (Status is OrderStatus.Open || Status is OrderStatus.WaitingDelivery)
            {
                Status = OrderStatus.Cancel;
                return Result.Ok();
            }
            return Result.Fail("Order already canceled or expired");
        }
        /// <summary>
        /// Pay for the order
        /// </summary>
        /// <returns></returns>
        public Result Pay()
        {
            if(Status is OrderStatus.Open)
            {
                Status = OrderStatus.WaitingDelivery;
                return Result.Ok();
            }
            return Result.Fail("Order already or already paid, canceled or expired");
        }
        /// <summary>
        /// Edit street to selivery
        /// </summary>
        /// <param name="newDeliveryStreet"></param>
        /// <returns></returns>
        public Result Edit(string newDeliveryStreet)
        {
            if (Status != OrderStatus.Open && Status != OrderStatus.WaitingDelivery)
                return Result.Fail("The order is not pending or no longer pending delivery");
            if (string.IsNullOrEmpty(newDeliveryStreet))
                return Result.Fail("New delivery address is empty");
            if (newDeliveryStreet.ToLower().Equals(StreetToDelivery.ToLower()))
                return Result.Fail("This address has already been entered");
            StreetToDelivery = newDeliveryStreet;
            return Result.Ok();
        }
        public Result ApplyDelivery()
        {
            if (Status != OrderStatus.WaitingDelivery)
                return Result.Fail("The order can`t be delivered");
            Status = OrderStatus.Delivered;
            return Result.Ok();
        }
    }
}
