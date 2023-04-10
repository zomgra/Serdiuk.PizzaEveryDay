using FluentResults;
using MediatR;

namespace Serdiuk.PizzaEveryDay.Application.Orders.GetWaitedOrder
{
    public class GetWaitedOrderQuery : IRequest<Result<IEnumerable<OrderDto>>>
    {

    }
}
