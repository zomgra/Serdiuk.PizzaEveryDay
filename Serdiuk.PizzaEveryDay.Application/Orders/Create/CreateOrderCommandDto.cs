namespace Serdiuk.PizzaEveryDay.Application.Orders.Create
{
    public class CreateOrderCommandDto
    {
        public List<int> ProductsId { get; set; }
        
        public string StreetToDelivery { get; set; }
        
        public string? PromoCode { get; set; }
    }
}
