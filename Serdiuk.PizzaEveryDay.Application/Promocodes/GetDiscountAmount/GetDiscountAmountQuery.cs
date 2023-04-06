using FluentResults;
using MediatR;

namespace Serdiuk.PizzaEveryDay.Application.Promocodes.GetDiscountAmount
{
    public class GetDiscountAmountQuery : IRequest<Result<int>>
    {
        /// <summary>
        /// Promo code
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// User Identifier for the ability to register who enters promotional codes and how much
        /// </summary>
        public Guid UserId { get; set; }
    }
}
