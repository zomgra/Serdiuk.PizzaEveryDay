using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.PizzaEveryDay.Application.Common.Interfaces;

namespace Serdiuk.PizzaEveryDay.Application.Promocodes.GetDiscountAmount
{
    public class GetDiscountAmountQueryHandler : IRequestHandler<GetDiscountAmountQuery, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public GetDiscountAmountQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<int>> Handle(GetDiscountAmountQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Code))
                return Result.Fail("Code is empty");
            var promocode = await _context.Promocodes.FirstOrDefaultAsync(p=>p.Code.ToLower().Equals(request.Code.ToLower()), cancellationToken);
            if (promocode == null)
                return Result.Fail("Promocode not found");
            if (promocode.UseCount == 0)
                return Result.Fail("Promocode is fully used");

            // TODO : Make in admin panel view used promocodes
            return Result.Ok(promocode.DiscountAmount);
        }
    }
}
