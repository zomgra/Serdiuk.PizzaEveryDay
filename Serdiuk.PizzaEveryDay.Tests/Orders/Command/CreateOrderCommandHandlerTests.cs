using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serdiuk.PizzaEveryDay.Application.Common.Mapper;
using Serdiuk.PizzaEveryDay.Application.Orders.Create;
using Serdiuk.PizzaEveryDay.Tests.Common;
using Xunit;

namespace Serdiuk.PizzaEveryDay.Tests.Orders.Command
{
    public class CreateOrderCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateOrderCommandHandler_Success()
        {
            // Arrange
            var command = new CreateOrderCommand()
            {
                ProductsId = new List<int> { 1, 2, 6 },
                PromoCode = null,
                StreetToDelivery = ApplicationContextFactory.StreetB,
                UserId = ApplicationContextFactory.UserIdB,
            };
            var handler = new CreateOrderCommandHandler(Context, Mapper);
            // Act

            var order = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(order.Value);
            Assert.Equal(166, order.Value.Products.Sum(p=>p.Cost));
            Assert.NotNull(await Context.Orders.SingleOrDefaultAsync(o => o.OrderId == order.Value.OrderId && o.UserId == ApplicationContextFactory.UserIdB));
        }

        [Fact]
        public async Task CreateOrderCommandHandler_EmptyProductsFailResult()
        {
            var command = new CreateOrderCommand()
            {
                ProductsId = new List<int> { },
                PromoCode = null,
                StreetToDelivery = ApplicationContextFactory.StreetB,
                UserId = ApplicationContextFactory.UserIdB,
            };
            var handler = new CreateOrderCommandHandler(Context, Mapper);
            // Act

            var order = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(order.IsFailed);
        }
        [Fact]
        public async Task CreateOrderCommandHandler_PermissionFail()
        {
            // Arrange
            var command = new CreateOrderCommand()
            {
                ProductsId = new List<int> { 1, 2, 6 },
                PromoCode = null,
                StreetToDelivery = ApplicationContextFactory.StreetB,
                UserId = ApplicationContextFactory.UserIdA,
            };
            var handler = new CreateOrderCommandHandler(Context, Mapper);
            // Act

            var order = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Null(await Context.Orders.SingleOrDefaultAsync(o => o.OrderId == order.Value.OrderId && o.UserId == ApplicationContextFactory.UserIdB));
        }
    }
}
