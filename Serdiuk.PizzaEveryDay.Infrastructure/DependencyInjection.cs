using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serdiuk.PizzaEveryDay.Application.Common.Interfaces;
using Serdiuk.PizzaEveryDay.Infrastructure.Persistance;

namespace Serdiuk.PizzaEveryDay.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(c => c.UseInMemoryDatabase("APP_DEV_ONLY"));
            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
            return services;
        }
    }
}
