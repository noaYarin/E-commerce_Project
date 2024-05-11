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

        public Product(string _name,int _price,Category _category) {
            this.name = _name;
            setPrice(_price);
        }

        public bool addProduct(Product product)
        {
            if(product != null)
            {
                
                return true;
            }
            return false;
        }

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
    }
}
