using System;

namespace CodeSmells
{
    public class ProductByWeight : Product, IEquatable<Product>
    {
        public override decimal ProductPrice => this.Weight.Value * this.Price;

        public override string ToString()
        {
            return $"{this.ProductName} ${this.ProductPrice} ({this.Weight} items at ${this.Price} per lb)";
        }

        public bool Equals(Product other)
        {
            if (other == null)
                return false;

            return this.ProductName.Equals(other.ProductName) &&
                   this.Weight.Value.Equals(other.Weight.Value) &&
                   this.Price.Equals(other.Price);
        }
    }
}
