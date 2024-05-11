using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Manager
    {
        private UserSeller[] sellers;
        private int sellersLogSize;
        private UserBuyer[] buyers;
        private Product[] productsArr;
        private int buyersLogSize;
        private string name;
        private int size = 2;
        private int sizeLogic = 0;
      
        public Manager(string _name)
        {
            this.name = _name;
            buyersLogSize = 0;
            buyers = new UserBuyer[size];
            sellersLogSize = 0;
            sellers = new UserSeller[size];
        }

 
        public bool addMyProduct(Product product)
        {
            Product[] newProduct;
            foreach (UserBuyer buyer in buyers)
            {
                //if (buyer.GetName() == "Chen")
                //    Console.WriteLine("exsit");
                Console.WriteLine("fff");
            }
            if(productsArr == null)
            {
                newProduct = new Product[1];
                newProduct[0] = new Product(product.GetProductName(), product.GetPrice()); 
            }

            else
            {
                newProduct = new Product[productsArr.Length+1];
                productsArr.CopyTo(newProduct, 0);
                newProduct[productsArr.Length] = new Product(product.GetProductName(), product.GetPrice());
            }
            productsArr = newProduct;

            return true; 
        }


        public bool payOrderAllCart(string name)
        {
            int totlePrice;
            foreach (UserBuyer buyer in buyers)
            {
                if (name == buyer.GetName())
                {
                    Console.WriteLine(buyer);
                }

                else
                    return false;
            }
            return true;
        }


        public bool addBuyer(string name, string password, Address address)
        {
            UserBuyer[] newBuyer;

            if (buyers == null) 
            {
                newBuyer = new UserBuyer[1];
                newBuyer[0] = new UserBuyer(name, password, address);
            }
            else
            {
                newBuyer = new UserBuyer[buyers.Length + size]; 
                buyers.CopyTo(newBuyer, 0);
                newBuyer[sizeLogic] = new UserBuyer(name, password, address); 
                sizeLogic++;
            }
            buyers = newBuyer;
            return false;
        }


        public void ShowAllProducts()
        {
            Console.WriteLine("\n***list all products***\n");
            if(productsArr != null) 
                foreach (Product productDetail in productsArr) 
                {
                    Console.WriteLine($"name: {productDetail.GetProductName()} price: {productDetail.GetPrice()}");
                }
        }
    }
}