using Xunit;

namespace CodeSmells.Test
{
    public class CodeSmellTests
    {
        [Fact]
        public void product_pricing_method_is_enum_type_price_method()
        {
            var expected = "CodeSmells.PriceMethodEnum";
            var actual = typeof(Product).GetField("PricingMethod").FieldType.FullName;
            Assert.Equal(expected, actual);
        }
    }
}
