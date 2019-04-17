using System;
using System.Collections.Generic;

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
            var product = GetProductStrategy(priceMethod, name, price);
            product.Quantity = quantity;

            return product;
        }

        public Product CreateProductFor(PriceMethodEnum priceMethod, string name, decimal price, decimal weight)
        {
            var product = GetProductStrategy(priceMethod, name, price);
            product.Weight = weight;

            return product;
        }

        private Product GetProductStrategy(PriceMethodEnum priceMethodEnum, string s, decimal price1)
        {
            var product = strategies[priceMethodEnum]();
            product.PricingMethod = priceMethodEnum;
            product.ProductName = s;
            product.Price = price1;
            return product;
        }
    }
}
