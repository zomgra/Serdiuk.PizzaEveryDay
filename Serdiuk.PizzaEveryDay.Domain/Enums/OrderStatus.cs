namespace Serdiuk.PizzaEveryDay.Domain.Enums
{
    /// <summary>
    /// Status of order
    /// </summary>
    public enum OrderStatus
    {
        Open = 0,
        WaitingDelivery = 1,
        Delivered = 2,
        Payed = 3,
        Cancel = 4,
        Expired = 5,
    }
}
