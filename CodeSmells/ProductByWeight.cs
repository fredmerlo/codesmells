namespace CodeSmells
{
    public class ProductByWeight : Product
    {
        public override decimal ProductPrice => this.Weight.Value * this.Price;

        public override string ToString()
        {
            return $"{this.ProductName} ${this.ProductPrice} ({this.Weight} items at ${this.Price} per lb)";
        }
    }
}
