using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSmells
{
    public class Order
    {
        public List<Product> Products;
        public string Name;
        public decimal Price => Products?.Aggregate(0m, (result, product) => result + product.ProductPrice) ?? 0m;

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Order {this.Name}");
            builder.AppendLine();

            this.Products.ForEach((product) => builder.AppendLine(product.ToString()));

            builder.AppendLine();
            builder.AppendLine($"Total ${this.Price}");

            return builder.ToString();
        }
    }
}