using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Seller : User
    {
        private List<Product> products;
        private int size = 2;

        public Seller(string name, string password, Address address) : base(name, password, address)
        {
            products = new List<Product>(size); 
        }

        public Seller(User others) : base(others)
        {
            products = new List<Product>(size); 
        }

        public Seller() : base() { }


        public Product GetProduct(string productName)
        {
            foreach (Product product in products)
            {
                if (product != null && product.Name.ToLower() == productName.ToLower())
                {
                    return product;
                }
            }
            return null;

        }

        public void SetProduct(Product productDetails)
        {
            products.Add(productDetails);
        }

        public override bool Equals(object obj)
        {
            if (Name == (string)obj)
                return true;
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            string baseString = base.ToString();
            foreach (var productDetail in products)
            {
                if (productDetail != null)
                    baseString += productDetail.ToString();
                else
                    break;
            }
            return baseString;
        }

        public int GetProductCount()
        {
            return products.Count;
        }
    }
}
