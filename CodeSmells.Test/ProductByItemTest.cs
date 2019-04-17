using Xunit;

namespace CodeSmells.Test
{
    public class ProductByItemTest
    {
        [Fact]
        public void product_by_item_subclasses_product()
        {
            var expected = "CodeSmells.Product";
            var actual = typeof(ProductByItem).BaseType.FullName;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void calculates_product_price_as_quantity_times_price()
        {
            var productByItem = new ProductByItem { ProductName = "Item", Quantity = 2, Price = 3m};
            var expected = 2 * 3;
            Assert.Equal(expected, productByItem.ProductPrice);
        }

        [Fact]
        public void to_string_returns_formatted_product_by_item_details()
        {
            var productByItem = new ProductByItem { ProductName = "Item", Quantity = 2, Price = 3m };
            var expected = "Item $6 (2 items at $3 each)";
            Assert.Equal(expected, productByItem.ToString());
        }
    }
}
