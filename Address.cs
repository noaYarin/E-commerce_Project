using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Address
    {
        string street;
        int numberOfStreet;
        string city;
        string country;


        public Address() { }

        //public Address(string city, string country)
        //{
        //    this.city = city;
        //    this.country = country;
        //}

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
                //this.street = street;
                //this.numberOfStreet = numberOfStreet;
                //this.city = city;
                //this.country = country;
                return true;
            }
            return false;
        }

        bool SetStreet(string street)
        {
            if (street != null && !IsContainDigit(street))
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
            if (city != null && !IsContainDigit(city))
            {
                this.city = city;
                return true;
            }
            return false;
        }

        bool SetCountry(string country)
        {
            if (country != null && !IsContainDigit(country))
            {
                this.country = country;
                return true;
            }
            return false;
        }


        public string GetStreet() { return this.street; }
        public string GetCity() { return this.city; }
        public string GetCountry() { return this.country; }
        public int GetNumberOfStreet() { return this.numberOfStreet; }



        bool IsContainDigit(string street)
        {
            foreach (char ch in street)
                if (ch >= '0' && ch <= '9')
                    return true;
            return false;
        }

        public string ToString()
        {
            return "Country: " + country + ", city: " + city + ", street: " + street + ", number: " + numberOfStreet;
            //Console.WriteLine($"Adress: Country: {this.country} City: {this.city} street: {this.street} number: {this.numberOfStreet}");

        }
    }
}
