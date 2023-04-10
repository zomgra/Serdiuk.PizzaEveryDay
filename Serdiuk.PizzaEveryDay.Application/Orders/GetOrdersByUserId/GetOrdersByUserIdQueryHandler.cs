using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.PizzaEveryDay.Application.Common.Interfaces;

namespace Serdiuk.PizzaEveryDay.Application.Orders.GetOrdersByUserId
{
    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, Result<IEnumerable<OrderDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOrdersByUserIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<OrderDto>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.AsNoTracking().Include(o=>o.Promocode).Include(o=>o.Products).Where(o=>o.UserId == request.UserId).ToListAsync();
            if (!orders.Any())
                return Result.Fail("you have no orders");

            
            var sordetOrders = orders.OrderByDescending(o=>o.Status == request.Status);
            var results = new List<OrderDto>();
            foreach (var order in sordetOrders)
            {
                results.Add(_mapper.Map<OrderDto>(order));
            }
               
            return Result.Ok<IEnumerable<OrderDto>>(results);
        }
    }
}
