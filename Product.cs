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

        public static int IdCounter 
        {
            get { return idCounter; }
            set { idCounter = value; } 
        }

        public int Id
        {
            get { return id; }
        } 

        public string Name 
        {
            get { return name; }
            set { name = value; } 
        }
        public int Price 
        {
            get { return price; }
            set { price = SetPrice(value); } 
        }
        internal Category Category
        {
            get { return category; }
            set { category = value; } 
        }

        public Product() { }
        public Product(string _name, int _price, Category _category)
        {
            id = IdCounter++;
            this.Name = _name;
            this.Price = _price;
            this.Category = _category;
            SetPrice(_price);
        }

        public Product(int id,string _name, int _price, Category _category)
        {
            this.id = id;
            this.Name = _name;
            this.Price = _price;
            this.Category = _category;
            SetPrice(_price);
        }

        public Product(Product _product) 
        {
            id = IdCounter++;
            this.Name = _product.Name;
            this.Price = _product.Price;
            this.Category= _product.Category;
            SetPrice(_product.Price);
        }

        public int SetPrice(int price)
        {
            if (price <= 0)
            {
               throw new ArgumentException("Invalid price");
            }
            return price;
        }

       
        public virtual string ToString()
        {
            return $"\t- ID:{Id}, Product name: {Name}, Price: {Price} ,Category: {Category.GetCategoryName()}\n";
        }
    }
}
