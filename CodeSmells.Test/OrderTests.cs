using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeSmells.Test
{
    public class OrderTests
    {
        [Fact]
        public void calculates_order_total_as_sum_of_product_price()
        {
            var order = new Order
            {
                Name = "Order",
                Products = new List<Product>
                {
                    ProductFactory.Instance.CreateProductFor(PriceMethodEnum.PerItem, "Item1", 3m, 2),
                    ProductFactory.Instance.CreateProductFor(PriceMethodEnum.PerPound, "Item2", 3m, 2m)
                }
            };
            Assert.Equal(12m, order.Price);
        }

        [Fact]
        public void to_string_returns_order_summary()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Order Order");
            builder.AppendLine();
            builder.AppendLine("Item1 $6 (2 items at $3 each)");
            builder.AppendLine("Item2 $6 (2 items at $3 per lb)");
            builder.AppendLine();
            builder.AppendLine("Total $12");

            var order = new Order
            {
                Name = "Order",
                Products = new List<Product>
                {
                    ProductFactory.Instance.CreateProductFor(PriceMethodEnum.PerItem, "Item1", 3m, 2),
                    ProductFactory.Instance.CreateProductFor(PriceMethodEnum.PerPound, "Item2", 3m, 2m)
                }
            };
            var expected = builder.ToString();
            Assert.Equal(expected, order.ToString());

        }
    }
}
