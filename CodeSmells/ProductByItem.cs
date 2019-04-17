using System;

namespace CodeSmells
{
    public class ProductByItem : Product, IEquatable<Product>
    {
        public override decimal ProductPrice => this.Quantity.Value * this.Price;

        public override string ToString()
        {
            return $"{this.ProductName} ${this.ProductPrice} ({this.Quantity} items at ${this.Price} each)";
        }

        public bool Equals(Product other)
        {
            if (other == null)
                return false;

            return this.ProductName.Equals(other.ProductName) &&
                   this.Quantity.Value.Equals(other.Quantity.Value) &&
                   this.Price.Equals(other.Price);
        }
    }
}
