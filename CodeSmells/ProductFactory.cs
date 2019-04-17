using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace CodeSmells
{
    public sealed class ProductFactory
    {
        private static Lazy<ProductFactory> instance = new Lazy<ProductFactory>(() => new ProductFactory());
        public static ProductFactory Instance => instance.Value;
        private Dictionary<PriceMethodEnum, Func<Product>> strategies;

        private ProductFactory()
        {
            strategies = new Dictionary<PriceMethodEnum, Func<Product>>
            {
                {PriceMethodEnum.PerItem, () => new ProductByItem()},
                {PriceMethodEnum.PerPound, () => new ProductByWeight()}
            };
        }

        public Product CreateProductFor(PriceMethodEnum priceMethod, string name, decimal price, int quantity)
        {
            var product = strategies[priceMethod]();
            product.ProductName = name;
            product.Price = price;
            product.Quantity = quantity;

            return product;
        }

        public Product CreateProductFor(PriceMethodEnum priceMethod, string name, decimal price, decimal weight)
        {
            var product = strategies[priceMethod]();
            product.ProductName = name;
            product.Price = price;
            product.Weight = weight;

            return product;
        }
    }
}
