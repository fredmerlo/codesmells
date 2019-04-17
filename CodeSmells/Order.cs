using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSmells
{
    public class Order
    {

        public List<Product> Products;

        public string Name;

        public decimal Price
        {

            get
            {

                if (this.Products == null)
                {
                    return 0m;
                }

                return this.Products.Aggregate(0m, (result, product) => result + product.ProductPrice);
            }
        }


        public override string ToString()
        {

            var builder = new StringBuilder();

            builder.AppendFormat("ORDER SUMMARY FOR {0}:", this.Name);
            builder.AppendLine();

            this.Products.ForEach((product) => builder.AppendLine(product.ToString()));

            builder.AppendFormat("Total Price: ${0}", this.Price);

            return builder.ToString();
        }

    }
}