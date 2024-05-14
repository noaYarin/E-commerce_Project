using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class UserBuyer
    {

        string name;
        string password;
        Address address;
        Order[] orders;
        Product[] products;

        public UserBuyer(){}
        public UserBuyer(string name, string password, Address address)
        {
            SetBuyer(name, password, address);
        }
        public UserBuyer(UserBuyer other)
        {
            SetBuyer(other.name, other.password, other.address);
         }

        public string GetName() { return name; }
        public string GetBuyerCity() { return address.GetCity(); }
      
        public bool SetBuyer(string name, string password, Address address)
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
            if (name != null && !IsContainDigit(name) && name.Length < 10)
            {
                return true;
            }
            return false;
        }


        public bool SetPassword(string password)
        {
            if (password != null && (password.Length >= 0 && password.Length <= 15))
            {
                this.password = password;
                return true;

            }

            return false;
        }

        public string ToString()
        {
            return "Customer name: " + name + ", password: " + password + ", Address: " + address.ToString(); 
        }

        public void ToStringAllProducts()
        {
            if(products != null)
                foreach (Product productDetail in products)
                {
                    Console.WriteLine(productDetail.ToString());
                }
        }


        public int GetPriceCart()
        {
            int priceCart = 0;
            if (products != null)
                foreach (Product productDetail in products)
                {
                    priceCart += productDetail.GetPrice();
                }
            return priceCart;
        }


        public bool IsContainDigit(string str)
        {
            foreach (char ch in str)
                if (ch >= '0' && ch <= '9')
                    return true;
            return false;
        }


        public bool SetProduct(Product productDetail)
        {
            Product[] newProduct;
            if(products == null)
            {
                newProduct = new Product[1];
                newProduct[0] = productDetail;
            }
            else
            {
                newProduct = new Product[products.Length + 1];
                products.CopyTo(newProduct, 0);
                newProduct[products.Length] = productDetail; 
            }
            products = newProduct;
            return true;
        }

    }
}
