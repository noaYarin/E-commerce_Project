using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace task_2
{
    internal class Product
    {
        private static int idCounter = 1;
        private readonly int id;
        private string name;
        private int price;
        private Category category;

        public Product() { }
        public Product(string _name, int _price, Category _category)
        {
            id = idCounter++;
            this.name = _name;
            this.price = _price;
            this.category = _category;
            SetPrice(_price);
        }

        public Product(int id,string _name, int _price, Category _category)
        {
            this.id = id;
            this.name = _name;
            this.price = _price;
            this.category = _category;
            SetPrice(_price);
        }

        public Product(Product _product) 
        {
            id = idCounter++;
            this.name = _product.name;
            this.price = _product.price;
            this.category= _product.category;
            SetPrice(_product.price);
        }

        public bool SetPrice(int price)
        {
            if (price <= 0)
            {
                Console.WriteLine("Invalid price");
                return false;
            }
            this.price = price;
            return true;
        }

        public string GetProductName() { return  name; }
        public int GetPrice() { return price; }
        public int GetId() { return id; }
        public Category GetCategory() { return category; }

        public virtual string ToString()
        {
            return $"\t- ID:{id}, Product name: {name}, Price: {price} ,Category: {category.GetCategoryName()}\n";
        }
    }
}
