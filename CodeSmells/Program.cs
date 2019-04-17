using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSmells
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                Name = "John Doe",
                Products = new List<Product> {
                    new Product {
                        ProductName = "Pulled Pork",
                        Price = 6.99m,
                        Weight = 0.5m,
                        PricingMethod = "PerPound"
                    },

                    new Product {
                        ProductName = "Coke",
                        Price = 3m,
                        Quantity = 2,
                        PricingMethod = "PerItem"
                    }
                }
            };

            Console.WriteLine(order);
        }
    }

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

    public class Product
    {
        public string ProductName;
        public decimal Price;
        public decimal? Weight;
        public int? Quantity;
        public string PricingMethod;

        public decimal ProductPrice
        {
            get
            {

                if (this.PricingMethod == "PerPound")
                {
                    return this.Weight.Value * this.Price;
                }

                return this.Quantity.Value * this.Price;
            }
        }

        public override string ToString()
        {

            if (this.PricingMethod == "PerPound")
            {
                return String.Format("{0} ${1} ({2} pounds at ${3} per pound)", this.ProductName, this.ProductPrice, this.Weight, this.Price);
            }

            return String.Format("{0} ${1} ({2} items at ${3} each)", this.ProductName, this.ProductPrice, this.Quantity, this.Price);
        }

    }
}
