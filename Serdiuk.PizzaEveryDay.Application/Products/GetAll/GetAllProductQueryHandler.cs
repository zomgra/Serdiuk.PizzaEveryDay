using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.PizzaEveryDay.Application.Common.Interfaces;

namespace Serdiuk.PizzaEveryDay.Application.Products.GetAll
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, Result<object>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllProductQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<object>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var pizzas = await _context.Pizzas.ToListAsync();
            var drinks = await _context.Drinks.ToListAsync();
            var sauces = await _context.Sauces.ToListAsync();

            if(!pizzas.Any() || !drinks.Any() || !sauces.Any())
            {
                return Result.Fail("No products found, please try again later");
            }

            var allProduct = new { pizzas, drinks, sauces };
            return allProduct.ToResult<object>();
        }
    }
}
