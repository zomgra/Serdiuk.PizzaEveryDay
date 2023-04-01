namespace Serdiuk.PizzaEveryDay.Domain.Enums
{
    /// <summary>
    /// Status of order
    /// </summary>
    public enum OrderStatus
    {
        Open = 0,
        WaitingDelivery = 1,
        Cancel = 2,
        Expired = 3,
    }
}
