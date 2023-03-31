using Serdiuk.PizzaEveryDay.Domain.Enums;

namespace Serdiuk.PizzaEveryDay.Application.Orders.GetOrdersByUserId
{
    public class GetOrdersByUserIdQueryDto
    {
        public OrderStatus? Status { get; set; }
    }
}
