using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class User
    {
        protected string name;
        protected string password;
        protected Address address;

        public User(string name, string password, Address address)
        {
            SetUser(name, password, address);
        }
        public User(User other)
        {
            SetUser(other.name, other.password, other.address);
        }
        public User() { }

        public string GetBuyerName() { return name; }
        public string GetBuyerPassword() { return password; }
        public Address GetAddress() { return address; }


        public bool SetUser(string name, string password, Address address)
        {
            if (SetUserName(name) && SetUserPassword(password))
            {
                this.address = new Address(address);
                this.name = name;
                this.password = password;
                return true;
            }
            return false;
        }


        public bool SetUserName(string name)
        {
            if (name != null && !Validation.IsContainDigit(name) && name.Length < 10)
            {
                return true;
            }
            return false;
        }

        public bool SetUserPassword(string password)
        {
            return Validation.IsValidPassword(password);
        }


        public virtual string ToString()
        {
            return "Name: " + name + ", Address: " + address.ToString() + "\n";
        }

    }
}
