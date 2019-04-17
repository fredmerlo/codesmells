using Xunit;

namespace CodeSmells.Test
{
    public class CodeSmellTests
    {
        [Fact]
        public void product_pricing_method_is_enum_type_price_method()
        {
            var actual = new Product();
            Assert.IsType<PriceMethodEnum>(actual.PricingMethod);
        }
    }
}
