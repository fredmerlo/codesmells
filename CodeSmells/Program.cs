using System;
using System.Collections.Generic;

namespace CodeSmells
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                Name = "John Doe",
                Products = new List<Product> {
                    new Product {
                        ProductName = "Pulled Pork",
                        Price = 6.99m,
                        Weight = 0.5m,
                        PricingMethod = "PerPound"
                    },

                    new Product {
                        ProductName = "Coke",
                        Price = 3m,
                        Quantity = 2,
                        PricingMethod = "PerItem"
                    }
                }
            };

            Console.WriteLine(order);
        }
    }
}
