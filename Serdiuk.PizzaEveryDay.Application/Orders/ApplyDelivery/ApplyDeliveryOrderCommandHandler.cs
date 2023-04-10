using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.PizzaEveryDay.Application.Common.Interfaces;

namespace Serdiuk.PizzaEveryDay.Application.Orders.ApplyDelivery
{
    public class ApplyDeliveryOrderCommandHandler : IRequestHandler<ApplyDeliveryOrderCommand, Result>
    {
        private readonly IApplicationDbContext _context;

        public ApplyDeliveryOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(ApplyDeliveryOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o=>o.OrderId == request.OrderId, cancellationToken);
            if(order == null)
                return Result.Fail("The order was not found or you do not have sufficient rights");

            var result = order.ApplyDelivery();
            if(result.IsFailed)
                return result;

            await _context.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
