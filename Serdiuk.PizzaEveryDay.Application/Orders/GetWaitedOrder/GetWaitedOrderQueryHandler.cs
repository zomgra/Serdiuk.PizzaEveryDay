using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.PizzaEveryDay.Application.Common.Interfaces;

namespace Serdiuk.PizzaEveryDay.Application.Orders.GetWaitedOrder
{
    public class GetWaitedOrderQueryHandler : IRequestHandler<GetWaitedOrderQuery, Result<IEnumerable<OrderDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetWaitedOrderQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<OrderDto>>> Handle(GetWaitedOrderQuery request, CancellationToken cancellationToken)
        {
            var orders =  await _context.Orders.Where(o => o.Status == Domain.Enums.OrderStatus.WaitingDelivery).ToListAsync(cancellationToken);
            if (orders.Any())
                return Result.Fail("No orders pending delivery found");

            return _mapper.Map<IEnumerable<OrderDto>>(orders).ToResult();
        }
    }
}
