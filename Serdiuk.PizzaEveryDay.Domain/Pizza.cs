using Serdiuk.PizzaEveryDay.Domain.Enums;

namespace Serdiuk.PizzaEveryDay.Domain
{
    public class Pizza : Product
    {
        public string Ingredients { get; set; }
        public override string Name { get ; set; }
        public override decimal Cost { get; set; }
        public override ProductType Type { get; set; } = ProductType.Pizza;
    }
}
