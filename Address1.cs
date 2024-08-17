using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    public class Address
    {
        private string street;
        private int numberOfStreet;
        private string city;
        private string country;

        public Address(string street, int numberOfStreet, string city, string country)
        {
            Street = street;
            NumberOfStreet = numberOfStreet;
            City = city;
            Country = country;
        }

        public Address(Address addr)
        {
            Street = addr.street;
            NumberOfStreet = addr.numberOfStreet;
            City = addr.city;
            Country = addr.country;
        }

        public Address() { }

        public string Street
        {
            get { return street; }
            set { street = SetStreet(value); }
        }

        public int NumberOfStreet
        {
            get { return numberOfStreet; }
            set { numberOfStreet = SetNumberOfStreet(value); }
        }

        public string City
        {
            get { return city; }
            set { city = SetCity(value); }
        }

        public string Country
        {
            get { return country; }
            set { country = SetCountry(value); }
        }

        private string SetStreet(string street)
        {
            if (street !="" && !Validation.IsContainDigit(street))
            {
                return street;
            }
            throw new ArgumentException("Enter street again");
        }

        int SetNumberOfStreet(int numberOfStreet)
        {
            if (numberOfStreet > 0 && numberOfStreet < 999)
            {
                return numberOfStreet;
            }
            throw new ArgumentException("Street number must be between 1 - 999");
            
        }

        string SetCity(string city)
        {
            if (city !="" && !Validation.IsContainDigit(city))
            {
                return city;
            }
            throw new ArgumentException("Enter city again");
        }

        string SetCountry(string country)
        {
            if (country !="" && !Validation.IsContainDigit(country))
            {
                return country;
            }
            throw new ArgumentException("Enter country again");
        }

        public override string ToString()
        {
            return "Country: " + Country + ", city: " + City + ", street: " + Street + ", number: " + NumberOfStreet;
        }
    }
}
