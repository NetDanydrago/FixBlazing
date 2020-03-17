using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingPizza.Shared;

namespace BlazingPizza.Server.Models
{
    public static class SeedData
    {
        public static void Initialize(PizzaStoreContext context)
        {
            var Specials = new PizzaSpecial[]
            {
                new PizzaSpecial
                {
                    Name = "Pizzaz clàsica de queso",
                    Description = "Es de queso y delicioso. ¿Porquè no querrias una?",
                    BasePrice = 189.99m,
                    ImageUrl = "images/pizzas/cheese.jpg"
                },

                new PizzaSpecial
                {
                    Name = "Tocinator",
                    Description = "Tiene todo tipo de tocino.",
                    BasePrice = 227.99m,
                    ImageUrl = "images/pizzas/bacon.jpg"
                },

                new PizzaSpecial
                {
                    Name = "Clàsica de peperoni",
                    Description = "Es la pizza con la que creciste, ¡pero ardientemente deliciosa!.",
                    BasePrice = 199.50m,
                    ImageUrl = "images/pizzas/pepperoni.jpg"
                },

                new PizzaSpecial
                {
                    Name = "Pollo bùfalo",
                    Description = "Pollopicante, salsa picante y queso azùl, garantizado que entraras en calor.",
                    BasePrice = 228.75m,
                    ImageUrl = "images/pizzas/meaty.jpg"
                },

                new PizzaSpecial
                {
                    Name = "Amantes del champiñòn",
                    Description = "Tiene champiñones. ¿No es obvio?",
                    BasePrice = 209.00m,
                    ImageUrl = "images/pizzas/mushroom.jpg"
                },

                new PizzaSpecial
                {
                    Name = "Hawaiana",
                    Description = "De piña, jamòn y queso ...",
                    BasePrice = 190.25m,
                    ImageUrl = "images/pizzas/hawaiian.jpg"
                },

                new PizzaSpecial
                {
                    Name = "Delicia vegetariana",
                    Description = "Es como una ensalada, pero en una pizza.",
                    BasePrice = 218.50m,
                    ImageUrl = "images/pizzas/salad.jpg"
                },

                new PizzaSpecial
                {
                    Name = "Margarita",
                    Description = "Pizza italiana tradicionalcon tomates y albahaca.",
                    BasePrice = 189.99m,
                    ImageUrl = "images/pizzas/margherita.jpg"
                },
            };

            context.Specials.AddRange(Specials);
            context.SaveChanges();

            var Toppings = new Topping[]
            {
                new Topping
                {
                    Name = "Queso extra",
                    Price = 47.50m
                },

                new Topping
                {
                    Name = "Tocino de pavo",
                    Price = 56.80m
                },

                new Topping
                {
                    Name = "Tocino de jabalì",
                    Price = 56.80m
                },

                new Topping
                {
                    Name = "Tocino de ternera",
                    Price = 56.80m
                },

                new Topping
                {
                    Name = "Tè y bollos",
                    Price = 95.00m
                },

                new Topping
                {
                    Name = "Bollos recièn horneados",
                    Price = 85.50m
                },

                new Topping
                {
                    Name = "Pimiento",
                    Price = 19.00m
                },

                new Topping
                {
                    Name = "Cebolla",
                    Price = 19.00m
                },

                new Topping
                {
                    Name = "Champiñones",
                    Price = 19.00m
                },

                new Topping
                {
                    Name = "Pepero ni",
                    Price = 19.00m
                },

                new Topping
                {
                    Name = "Salchicha de pato",
                    Price = 60.80m
                },

                new Topping
                {
                    Name = "Albòndiga de venado",
                    Price = 47.50m
                },

                new Topping
                {
                    Name = "Cubierta de langosta",
                    Price = 1225.50m
                },

                new Topping
                {
                    Name = "Caviar de esturiòn",
                    Price = 1933.25m
                },

                new Topping
                {
                    Name = "Corazones de alcavhofa",
                    Price = 64.60m
                },

                new Topping
                {
                    Name = "Tomates frescos",
                    Price = 39.00m
                },

                new Topping
                {
                    Name = "Albahaca",
                    Price = 39.00m
                },

                new Topping
                {
                    Name = "Filete",
                    Price = 161.50m
                },

                new Topping
                {
                    Name = "Pimientos picantes",
                    Price = 79.80m
                },

                new Topping
                {
                    Name = "Pollo bùfalo",
                    Price = 95.00m
                },

                new Topping
                {
                    Name = "Queso azùl",
                    Price = 47.50m
                },
            };

            context.Toppings.AddRange(Toppings);
            context.SaveChanges();
        }
    }
}
