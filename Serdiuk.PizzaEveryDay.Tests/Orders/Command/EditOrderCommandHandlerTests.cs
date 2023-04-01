using Serdiuk.PizzaEveryDay.Application.Orders.Edit;
using Serdiuk.PizzaEveryDay.Tests.Common;
using Xunit;

namespace Serdiuk.PizzaEveryDay.Tests.Orders.Command
{
    public class EditOrderCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task EditOrderCommandHandler_Success()
        {
            // Arrange
            var command = new EditOrderCommand()
            {
                OrderId = 1,
                Street = ApplicationContextFactory.StreetB,
                UserId = ApplicationContextFactory.UserIdA,
            };
            var handler = new EditOrderCommandHandler(Context, Mapper);
            // Act

            var order = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(order.Value.StreetToDelivery.Equals(ApplicationContextFactory.StreetB));
            Assert.NotNull(order.Value);
        }

        [Fact]
        public async Task EditOrderCommandHandler_NullStreetChanged()
        {
            // Arrange
            var command = new EditOrderCommand()
            {
                OrderId = 1,
                Street = string.Empty,
                UserId = ApplicationContextFactory.UserIdA,
            };
            var handler = new EditOrderCommandHandler(Context, Mapper);
            // Act

            var order = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(order.IsFailed);
        }
    }
}
