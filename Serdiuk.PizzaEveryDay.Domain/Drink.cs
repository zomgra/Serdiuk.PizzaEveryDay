using Serdiuk.PizzaEveryDay.Domain.Enums;

namespace Serdiuk.PizzaEveryDay.Domain
{
    public class Drink : Product
    {
        public float Amount { get; set; }
        public override string Name { get; set; }
        public override decimal Cost { get; set; }
        public override ProductType Type { get; set; } = ProductType.Drink;
    }
}
