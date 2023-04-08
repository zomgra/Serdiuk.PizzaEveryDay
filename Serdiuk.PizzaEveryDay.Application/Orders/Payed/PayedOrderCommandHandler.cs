using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.PizzaEveryDay.Application.Common.Interfaces;

namespace Serdiuk.PizzaEveryDay.Application.Orders.Payed
{
    public class PayedOrderCommandHandler : IRequestHandler<PayedOrderCommand, Result<OrderDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PayedOrderCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        public async Task<Result<OrderDto>> Handle(PayedOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o=>o.OrderId == request.OrderId, cancellationToken);
            if (order == null || order.UserId != request.UserId)
                return Result.Fail("The order was not found or you do not have sufficient rights");

            var result = order.Pay();

            if (result.IsFailed)
                return result;
            
            await _context.SaveChangesAsync(cancellationToken);


            return _mapper.Map<OrderDto>(order).ToResult().WithErrors(result.Errors);
        }
    }
}
