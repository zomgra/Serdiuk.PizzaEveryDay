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
            var orders = _context.Orders.AsNoTracking().Include(o=>o.Products).Where(o=>o.UserId == request.UserId);
            if (!orders.Any())
                return Result.Fail("you have no orders");

            if (!request.Status.HasValue)
            {
                var result = await orders.ProjectTo<OrderDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
                return Result.Ok<IEnumerable<OrderDto>>(result);
            }
            var sordetOrders = orders.OrderByDescending(o=>o.Status == request.Status);
            var results = await sordetOrders.ProjectTo<OrderDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return Result.Ok<IEnumerable<OrderDto>>(results);
        }
    }
}
