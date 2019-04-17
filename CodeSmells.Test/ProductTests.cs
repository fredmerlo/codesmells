using Xunit;

namespace CodeSmells.Test
{
    public class ProductTests
    {
        [Fact]
        public void product_pricing_method_is_enum_type_price_method()
        {
            var expected = "CodeSmells.PriceMethodEnum";
            var actual = typeof(Product).GetField("PricingMethod").FieldType.FullName;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void product_is_abstract_class()
        {
            var actual = typeof(Product).IsAbstract;
            Assert.True(actual);
        }

        [Fact]
        public void product_price_property_is_abstract()
        {
            var actual = typeof(Product).GetProperty("ProductPrice").GetMethod.IsAbstract;
            Assert.True(actual);
        }

        [Fact]
        public void product_to_string_is_abstract()
        {
            var actual = typeof(Product).GetMethod("ToString").IsAbstract;
            Assert.True(actual);
        }
    }
}
