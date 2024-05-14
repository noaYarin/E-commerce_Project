using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Product
    {
        private string name;
        private int price;
        private Category category;
        private bool hasSpecialBox;
        private int extraPrice;
        public Product(string _name,int _price) { 
            this.name = _name;
            this.price = _price;
            setPrice(_price);
        }

        public Product(string _name, int _price, bool _hasSpecialBox, int _extraPrice)
        {
            this.name = _name;
            this.price = _price;
            this.hasSpecialBox = _hasSpecialBox;
            this.extraPrice = _extraPrice;
            setPrice(_price);
        }

        public string GetProductName() { return  name; }
        public int GetPrice() { return price; }
        public bool GetHasSpecialBox() { return hasSpecialBox; }
        public int GetExtraPrice() {  return extraPrice; }

        public bool setPrice(int price)
        {
            if(price <= 0)
            {
                Console.WriteLine("Invalid price");
                return false;
            }
            this.price = price;
            return true;
        }

        public string ToString()
        {
            return $"\t- product name: {name} price: {price} category: {category} special box: {hasSpecialBox} extra price: {extraPrice}";
        }
    }
}
