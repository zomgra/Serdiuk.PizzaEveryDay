namespace Serdiuk.PizzaEveryDay.Application.Orders.Edit
{
    public class EditOrderCommandDto
    {
        /// <summary>
        /// Identifier order
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// New delivery street
        /// </summary>
        public string Street { get; set; }
    }
}
