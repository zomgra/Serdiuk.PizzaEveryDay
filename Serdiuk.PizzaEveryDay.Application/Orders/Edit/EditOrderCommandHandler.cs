using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.PizzaEveryDay.Application.Common.Interfaces;

namespace Serdiuk.PizzaEveryDay.Application.Orders.Edit
{
    public class EditOrderCommandHandler : IRequestHandler<EditOrderCommand, Result<OrderDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EditOrderCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        public async Task<Result<OrderDto>> Handle(EditOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o=>o.OrderId == request.OrderId && o.UserId == request.UserId, cancellationToken);
            if(order == null)
                return Result.Fail("The order was not found or you do not have sufficient rights");

            var result = order.Edit(request.Street);

            if(result.IsFailed)
                return result;

            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<OrderDto>(result).ToResult();   
        }
    }
}
