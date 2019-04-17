using Xunit;

namespace CodeSmells.Test
{
    public class ProductByWeightTest
    {
        [Fact]
        public void product_by_weight_subclasses_product()
        {
            var expected = "CodeSmells.Product";
            var actual = typeof(ProductByItem).BaseType.FullName;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void calculates_product_price_as_weight_times_price()
        {
            var productByWeight = new ProductByWeight { ProductName = "Item", Weight = 2, Price = 3m };
            var expected = 2 * 3;
            Assert.Equal(expected, productByWeight.ProductPrice);
        }

        [Fact]
        public void to_string_returns_formatted_product_by_item_details()
        {
            var productByWeight = new ProductByWeight { ProductName = "Item", Weight = 2, Price = 3m };
            var expected = "Item $6 (2 items at $3 per lb)";
            Assert.Equal(expected, productByWeight.ToString());
        }
    }
}
