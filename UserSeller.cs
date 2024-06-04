using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class UserSeller
    {
        private string name;
        private string password;
        private Address address;
        private Product[] products;
        private int productsSellerLogSize = 0;
        private const int size = 2;

        public UserSeller() {
            products = new Product[size];
        }

        public UserSeller(string name, string password, Address address)
        {
            SetSeller(name, password, address);
        }

        public UserSeller(UserSeller other)
        {
            SetSeller(other.name, other.password, other.address);
        }

         public bool AddProduct(string name, int price, Category category)
           {
            Product[] tempNewProducts;
            Product newProduct = new Product(name,price, category);

            if (productsSellerLogSize == products.Length)
            {
                tempNewProducts = new Product[products.Length * 2];
                products.CopyTo(tempNewProducts, 0);
                products = tempNewProducts;
            }
            products[productsSellerLogSize] = newProduct;
            productsSellerLogSize++;
            return true;
           }

        public bool SetSeller(string name, string password, Address address)
        {
            if (SetName(name) && SetPassword(password))
            {
                this.address = new Address(address); 
                this.name = name;
                return true;
            }
            return false;
        }

        bool SetName(string name)
        {
            if (name != null && !Validation.IsContainDigit(name) && name.Length < 10)
            {
                return true;
            }
            return false;
        }


        public bool SetPassword(string password)
        {
           return Validation.IsValidPassword(password);
        }
        
        public string GetSellerName()
        {
            return name;
        }
        public void ToStringAllProducts()
        {
            if (products != null)
            {
                foreach (var productDetail in products)
                {
                    if (productDetail != null)
                        Console.WriteLine(productDetail.ToString());
                }
            }
        }
        public string ToString()
        {
            return "Status: Seller, name: " + name + ", Address: " + address.ToString();
        }

    }
}
