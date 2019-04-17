using Xunit;

namespace CodeSmells.Test
{
    public class ProductFactoryTests
    {
        [Fact]
        public void can_create_product_instance_for_price_method_by_item()
        {
            var expected = new ProductByItem { ProductName = "Item", Quantity = 2, Price = 3m };
            var actual = ProductFactory.Instance.CreateProductFor(PriceMethodEnum.PerItem, "Item", 3m, 2) as ProductByItem;
            Assert.True(expected.Equals(actual));
        }

        [Fact]
        public void can_create_product_instance_for_price_method_by_weight()
        {
            var expected = new ProductByWeight { ProductName = "Item", Weight = 2m, Price = 3m };
            var actual = ProductFactory.Instance.CreateProductFor(PriceMethodEnum.PerPound, "Item", 3m, 2m) as ProductByWeight;
            Assert.True(expected.Equals(actual));
        }
    }
}
