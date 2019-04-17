using System;

namespace CodeSmells
{
    public class ProductByItem : Product
    {
        public override decimal ProductPrice => this.Quantity.Value * this.Price;

        public override string ToString()
        {
            return $"{this.ProductName} ${this.ProductPrice} ({this.Quantity} items at ${this.Price} each)";
        }
    }
}
