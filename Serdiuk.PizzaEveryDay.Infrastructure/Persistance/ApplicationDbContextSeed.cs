﻿using Serdiuk.PizzaEveryDay.Domain;

namespace Serdiuk.PizzaEveryDay.Infrastructure.Persistance
{
    public static class ApplicationDbContextSeed
    {
        public static void Initialize(ApplicationDbContext context)
        {
            var pizzas = new List<Pizza>()
            {
                new Pizza
                {
                    Cost = 89,
                    Ingredients = "Salami, hunting sausages, Mozzarella cheese, pickled cucumber, pickled onion, signature tomato sauce",
                    Name = "Hunting",
                    ImageUrl = "https://amato-pizza.ru/upload/iblock/855/855bb1e38b9da33d4292edac53896c36.jpg",
                },
                new Pizza
                {
                    Cost = 65,
                    Ingredients = "Mozzarella cheese, tomato, signature tomato sauce, spices.",
                    Name = "Margarita",
                    ImageUrl = "https://amato-pizza.ru/upload/iblock/41f/41f4f5165b43e3ee5beba6f8706f9b7c.jpg"
                },
                new Pizza
                {
                    Name = "Mix Meat White",
                    Cost = 145,
                    Ingredients = "Chicken, hunting sausages, bacon, Mozzarella cheese, tomatoes, cream sauce.",
                    ImageUrl = "https://amato-pizza.ru/upload/iblock/943/943648db1a6dbe2899aa739ef717706c.jpg"
                },
                new Pizza
                {
                    Name = "Four cheeses",
                    Cost = 111,
                    Ingredients = "Mozzarella cheese, Dor Blue cheese, cream cheese, Gouda cheese, cream sauce.",
                    ImageUrl = "https://amato-pizza.ru/upload/iblock/25d/25d0a14de0efff5d5b49aa5a786c3151.jpg",
                }
            };
            var drinks = new List<Drink>()
            {
                new Drink
                {
                    Name = "Cola",
                    Amount = 1,
                    Cost = 44,
                    ImageUrl = "http://www.pizzacity.dp.ua/wp-content/uploads/2021/01/Coca-Cola.jpg"
                },
                new Drink
                {
                    Name = "Water",
                    Amount = .5f,
                    Cost = 10,
                    ImageUrl = "https://pizzaday.eatery.club/storage/pizzaday/product/icon/8246/conversions/5f9f5a497569f8e1a8639faef4881d1c-optimized.png"
                },
                new Drink
                {
                    Name = "Fanta",
                    Amount = 1.5f,
                    Cost = 55,
                    ImageUrl = "https://pizzaday.eatery.club/storage/pizzaday/product/icon/1372/1dc792be5e816fd310583443eba943ec.jpg"
                }
            };
            var sauces = new List<Sauce>()
            {
                new Sauce
                {
                    Name = "BBQ",
                    Cost = 12,
                    Taste = "BBQ",
                    ImageUrl = "https://www.kfc-ukraine.com/admin/files/3827.jpg"
                },
                new Sauce
                {
                    Name = "Cheese",
                    Taste = "Add life and interesting taste to sides with dipping sauce",
                    Cost = 12,
                    ImageUrl = "https://www.kfc-ukraine.com/admin/files/3823.jpg"
                },
                new Sauce
                {
                    Name = "Sweet and sour",
                    Cost = 12,
                    Taste = "Add life and interesting taste to sides with dipping sauce",
                    ImageUrl = "https://www.kfc-ukraine.com/admin/files/3828.jpg"
                }
            };
            var promocodes = new List<Promocode>
            {
                new Promocode
                {
                    UseCount = 100,
                    Code = "test",
                    DiscountAmount = 10,
                }
            };
            if (!context.Products.Any())
            {
                context.AddRange(pizzas);
                context.AddRange(drinks);
                context.AddRange(sauces);
                context.AddRange(promocodes);

                context.SaveChanges();
            }
        }
    }
}
