using Microsoft.EntityFrameworkCore;
using Serdiuk.PizzaEveryDay.Domain;

namespace Serdiuk.PizzaEveryDay.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Sauce> Sauces { get; set; }
        public DbSet<Promocode> Promocodes { get; set; }
        public DbSet<Order> Orders { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
