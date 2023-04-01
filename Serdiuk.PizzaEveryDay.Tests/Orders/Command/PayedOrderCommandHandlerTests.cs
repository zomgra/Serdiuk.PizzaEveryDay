using Serdiuk.PizzaEveryDay.Application.Orders.Edit;
using Serdiuk.PizzaEveryDay.Application.Orders.Payed;
using Serdiuk.PizzaEveryDay.Tests.Common;
using Xunit;

namespace Serdiuk.PizzaEveryDay.Tests.Orders.Command
{
    public class PayedOrderCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task PayedOrderCommandHandler_Success()
        {
            // Arrange
            var command = new PayedOrderCommand()
            {
                OrderId = 1,
                UserId = ApplicationContextFactory.UserIdA,
            };
            var handler = new PayedOrderCommandHandler(Context);
            // Act

            var order = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(order.IsSuccess);
        }
        [Fact]
        public async Task PayedOrderCommandHandler_AlreadyPayedOrderFail()
        {
            // Arrange
            var command = new PayedOrderCommand()
            {
                OrderId = 3,
                UserId = ApplicationContextFactory.UserIdA,
            };
            var handler = new PayedOrderCommandHandler(Context);
            // Act

            var order = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(order.IsFailed);
        }
        [Fact]
        public async Task PayedOrderCommandHandler_UserIdOrderFail()
        {
            // Arrange
            var command = new PayedOrderCommand()
            {
                OrderId = 1,
                UserId = ApplicationContextFactory.UserIdB,
            };
            var handler = new PayedOrderCommandHandler(Context);
            // Act

            var order = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(order.IsFailed);
        }
    }
}
