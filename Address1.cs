using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Address
    {
        private string street;
        private int numberOfStreet;
        private string city;
        private string country;

        public Address(string street, int numberOfStreet, string city, string country)
        {
            SetAdress(street, numberOfStreet, city, country);
        }

        public Address(Address addr)
        {
            SetAdress(addr.street, addr.numberOfStreet, addr.city, addr.country);
        }

        public bool SetAdress(string street, int numberOfStreet, string city, string country)
        {
            if (SetStreet(street) && SetNumberOfStreet(numberOfStreet) && SetCity(city) && SetCountry(country))
            {
                return true;
            }
            return false;
        }

        bool SetStreet(string street)
        {
            if (street != null && !Validation.IsContainDigit(street))
            {
                this.street = street;
                return true;
            }
            return false;
        }

        bool SetNumberOfStreet(int numberOfStreet)
        {
            if (numberOfStreet > 0 && numberOfStreet < 999)
            {
                this.numberOfStreet = numberOfStreet;
                return true;
            }
            return false;
        }

        bool SetCity(string city)
        {
            if (city != null && !Validation.IsContainDigit(city))
            {
                this.city = city;
                return true;
            }
            return false;
        }

        bool SetCountry(string country)
        {
            if (country != null && !Validation.IsContainDigit(country))
            {
                this.country = country;
                return true;
            }
            return false;
        }


        public string GetStreet() { return street; }
        public string GetCity() { return city; }
        public string GetCountry() { return country; }
        public int GetNumberOfStreet() { return numberOfStreet; }


        public string ToString()
        {
            return "Country: " + country + ", city: " + city + ", street: " + street + ", number: " + numberOfStreet;
        }
    }
}
