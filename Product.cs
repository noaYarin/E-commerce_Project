﻿using System;
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
        public readonly int id;
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

        public Product(Product _product) 
        {
            id = idCounter++;
            this.name = _product.name;
            this.price = _product.price;
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

        public virtual string ToString()
        {
            return $"\t- ID:{id}, product name: {name}, price: {price} ,category: {category.GetCategoryName()}";
        }
    }
}
