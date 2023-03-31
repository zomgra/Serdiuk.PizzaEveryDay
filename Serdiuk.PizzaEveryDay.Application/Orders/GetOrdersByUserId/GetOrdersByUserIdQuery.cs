using FluentResults;
using MediatR;
using Serdiuk.PizzaEveryDay.Domain.Enums;

namespace Serdiuk.PizzaEveryDay.Application.Orders.GetOrdersByUserId
{
    public class GetOrdersByUserIdQuery : IRequest<Result<IEnumerable<OrderDto>>>
    {
        public Guid UserId { get; set; }
        public OrderStatus? Status { get; set; }
    }
}
