using Serdiuk.PizzaEveryDay.Domain.Enums;

namespace Serdiuk.PizzaEveryDay.Domain
{
    public abstract class Product
    {
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public abstract string Name { get; set; }
        public abstract decimal Cost { get; set; }
        public abstract ProductType Type { get; set; }
    }
}
