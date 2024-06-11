using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Seller: User
    {
        protected Product[] products;
        private int size = 2;
        private int productLogicSize = 0;

        public Seller(string name, string password, Address address) :base(name, password, address)
        {
            this.name = name;
            this.password = password;
            this.address = address;
            products = new Product[size];
        }

        public Seller(User others):base(others) 
        {
            products = new Product[size];
        }

        public Product GetProduct(string productName)
        {
            foreach (Product product in products)
            {
                if(product.GetProductName() == productName)
                    return product;
            }
            return null;
        }

        public bool SetProduct(Product productDetails)
        {
            Product[] tempNewProducts;
            if (productLogicSize == products.Length)
            {
                tempNewProducts = new Product[products.Length * size];
                products.CopyTo(tempNewProducts, 0);
                products = tempNewProducts;

            }
            products[productLogicSize] = productDetails;
            productLogicSize++;
            return true;
        }


        public string ToString()
        {
            string res = "";
            foreach (var productDetail in products)
            {
                if (productDetail != null)
                    res += GetBuyerName() + productDetail.ToString();
                else
                    break;
            }
            return res;
        }

    }
}
