using FluentResults;

namespace Serdiuk.PizzaEveryDay.Domain
{
    public class Promocode
    {
        /// <summary>
        /// Promocode identitfier
        /// </summary>
        public int PromocodeId { get; init; }
        /// <summary>
        /// Code to activate
        /// </summary>
        public string Code { get; init; }
        /// <summary>
        /// Number of uses
        /// </summary>
        public int UseCount { get; set; }
        /// <summary>
        /// Count of discount
        /// </summary>
        public int DiscountAmount { get; init; }

        public Result Use()
        {
            if (UseCount == 0)
                return Result.Fail("Use max count");
            UseCount--;
            return Result.Ok();
        }
    }
}
