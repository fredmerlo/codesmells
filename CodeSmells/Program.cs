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
                Name = "Foo",
                Products = new List<Product>
                {
                    ProductFactory.Instance.CreateProductFor(PriceMethodEnum.PerItem, "Item1", 3m, 2),
                    ProductFactory.Instance.CreateProductFor(PriceMethodEnum.PerPound, "Item2", 3m, 2m)
                }
            };

            Console.WriteLine(order);
        }
    }
}
