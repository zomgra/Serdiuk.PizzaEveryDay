using AutoMapper;
using Serdiuk.PizzaEveryDay.Application.Common.Mapper;
using Serdiuk.PizzaEveryDay.Infrastructure.Persistance;

namespace Serdiuk.PizzaEveryDay.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly ApplicationDbContext Context;
        protected readonly IMapper Mapper;
        public TestCommandBase()
        {
            Context = ApplicationContextFactory.Create();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApplicationMapper>());
            Mapper = config.CreateMapper();
        }

        public void Dispose()
        {
            ApplicationContextFactory.Destroy(Context);
        }
    }
}
