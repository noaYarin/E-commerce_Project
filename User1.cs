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
        private string name;
        private string password;
        private Address address;

        public string Name {
            get { return name; }
            set { name = SetUserName(value); } 
        }

        public string Password {
            get { return password; }
            set { password = SetUserPassword(value); } 
        }
        public Address Address {
            get { return address; }
            set { address = new Address(value); } 
        }

        public User(string name, string password, Address address)
        {
            SetUser(name, password, address);
        }
        public User(User other)
        {
            SetUser(other.Name, other.Password, other.Address);
        }
        public User() { }


        public void SetUser(string name, string password, Address address)
        {
           Address = new Address(address);
           Name = name;
           Password = password;
        }


        public string SetUserName(string name)
        {
            if (name != null && !Validation.IsContainDigit(name) && name.Length < 10)
            {
                return name;
            }
            throw new ArgumentException("Name contains digit");
        }

        public string SetUserPassword(string password)
        {
            if(Validation.IsValidPassword(password))
                return password;
            throw new ArgumentException("Password should to be at least 4 charecters including a special character: {! @ # & $ ?}");  //Invalid password
        }


        public virtual string ToString()
        {
            return "Name: " + Name + ", Address: " + Address.ToString() + "\n";
        }

    }
}
