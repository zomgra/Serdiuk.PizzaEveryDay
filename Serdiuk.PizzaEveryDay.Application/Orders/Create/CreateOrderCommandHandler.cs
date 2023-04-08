using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.PizzaEveryDay.Application.Common.Interfaces;
using Serdiuk.PizzaEveryDay.Domain;

namespace Serdiuk.PizzaEveryDay.Application.Orders.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<OrderDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<OrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            if (!request.ProductsId.Any())
                return Result.Fail("You cart is empty");

            Promocode promocode = null;
            if (request.PromoCode != null)
            {
                promocode = await _context.Promocodes.FirstOrDefaultAsync(c => c.Code.Equals(request.PromoCode.ToLower()), cancellationToken);
            }

            var products = request.ProductsId
                .Join(_context.Products, id => id, prod => prod.ProductId, (id, prod) => prod)
                .ToList();
            if (!products.Any())
                return Result.Fail("An error occurred, please try again");

            var order = new Order(request.UserId, request.StreetToDelivery) { Promocode = promocode, Products = products };
            await _context.Orders.AddAsync(order, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            var result = _mapper.Map<OrderDto>(order);
            return result.ToResult();
        }
    }
}
