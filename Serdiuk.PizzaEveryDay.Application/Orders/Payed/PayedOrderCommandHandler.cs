using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.PizzaEveryDay.Application.Common.Interfaces;

namespace Serdiuk.PizzaEveryDay.Application.Orders.Payed
{
    public class PayedOrderCommandHandler : IRequestHandler<PayedOrderCommand, Result>
    {
        private readonly IApplicationDbContext _context;

        public PayedOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(PayedOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o=>o.OrderId == request.OrderId, cancellationToken);
            if (order == null || order.UserId != request.UserId)
                return Result.Fail("The order was not found or you do not have sufficient rights");

            var result = order.Pay();

            if (result.IsFailed)
                return result;
            
            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
