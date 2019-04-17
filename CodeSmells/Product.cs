using System;

namespace CodeSmells
{
    public enum PriceMethodEnum
    {
        PerPound,
        PerItem
    }
    public abstract class Product
    {
        public string ProductName;
        public decimal Price;
        public decimal? Weight;
        public int? Quantity;
        public PriceMethodEnum PricingMethod;

        public abstract decimal ProductPrice
        {
            get;
        }

        public abstract override string ToString();
    }
}