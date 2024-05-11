using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class UserSeller
    {
        string name;
        string password;
        Address address;
        Product[] products;

        public void AddProduct(Product product)
        {

        }
        public UserSeller(string name, string password, Address address)
        {
            SetSeller(name, password, address);

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
            if (name != null && !IsContainDigit(name) && name.Length < 10)
            {
                return true;
            }
            return false;
        }


        public bool SetPassword(string password)
        {
            if (password != null && (password.Length >= 4 && password.Length <= 10))
            {
                this.password = password;
                return true;

            }

            return false;
        }


        public string ToString()
        {
            return "Status: Seller, name: " + name + ", password: " + password + ", Address: " + address.ToString();
        }


        public bool IsContainDigit(string str)
        {
            foreach (char ch in str)
                if (ch >= '0' && ch <= '9')
                    return true;
            return false;
        }

    }
}
