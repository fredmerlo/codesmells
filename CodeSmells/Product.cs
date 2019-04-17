using System;

namespace CodeSmells
{
    public enum PriceMethodEnum
    {
        PerPound,
        PerItem
    }
    public class Product
    {
        public string ProductName;
        public decimal Price;
        public decimal? Weight;
        public int? Quantity;
        public PriceMethodEnum PricingMethod;

        public decimal ProductPrice
        {
            get
            {

                if (this.PricingMethod == PriceMethodEnum.PerPound)
                {
                    return this.Weight.Value * this.Price;
                }

                return this.Quantity.Value * this.Price;
            }
        }

        public override string ToString()
        {

            if (this.PricingMethod == PriceMethodEnum.PerPound)
            {
                return String.Format("{0} ${1} ({2} pounds at ${3} per pound)", this.ProductName, this.ProductPrice, this.Weight, this.Price);
            }

            return String.Format("{0} ${1} ({2} items at ${3} each)", this.ProductName, this.ProductPrice, this.Quantity, this.Price);
        }

    }
}