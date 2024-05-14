using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Manager
    {
        private UserSeller[] sellers;
        private int sellersLogSize=0;
        private UserBuyer[] buyers;
        private int buyersLogSize=0;
        private string name;
        private int size = 2;
        private Product[] productsArr;

        public Manager(string _name)
        {
            this.name = _name;
            //buyers = new UserBuyer[size];
            sellers = new UserSeller[size];
        }


       
        public bool addBuyer(string name, string password, Address address)
        {
            UserBuyer[] tempNewBuyers;
            UserBuyer temp = new UserBuyer();

            if (buyers == null)
            {
                tempNewBuyers = new UserBuyer[size];
                tempNewBuyers[0] = new UserBuyer(name, password, address);
                buyers = tempNewBuyers;
            }
            else
            {
                if (temp.SetBuyer(name, password, address))
                {
                    tempNewBuyers = new UserBuyer[buyers.Length + size];
                    buyers.CopyTo(tempNewBuyers, 0);
                    tempNewBuyers[buyersLogSize] = temp;
                    buyers = tempNewBuyers;
                }
                else
                {
                    Console.WriteLine("Invalid parameter!!");
                    return false;
                }
            }
            buyersLogSize++;
            return true;
        }


        public bool addSeller(string name, string password, Address address)
        {
            UserSeller[] tempNewSellers;

            if (sellers == null)
            {
                tempNewSellers = new UserSeller[1];
                tempNewSellers[0] = new UserSeller(name, password, address);
            }
            else
            {
                tempNewSellers = new UserSeller[sellers.Length + size];
                sellers.CopyTo(tempNewSellers, 0);
                tempNewSellers[sellersLogSize] = new UserSeller(name, password, address);
                sellersLogSize++;
            }
            sellers = tempNewSellers;
            return true;
        }

        public void addProductToSeller(string name,int price,string sellerName)
        {
            foreach (var seller in sellers)
            {
                if(seller.getSellerName()!= null && seller.getSellerName() == sellerName) {
                    seller.addProduct(name, price);
                }
            }

        }

        public bool addMyProduct(Product product, string name)
        {
            Product[] newProduct;
            foreach (UserBuyer buyer in buyers)
            {
               
                if(buyer.GetName() == name)
                {
                    buyer.SetProduct(product);
                    return true;
                }
            }

            return false; 
        }


        public bool payOrderAllCart(string name)
        {
            int price=0;
            foreach (UserBuyer buyer in buyers)
            {
                if (buyer != null) 
                    if (name == buyer.GetName())
                    {
                        price = buyer.GetPriceCart();
                        Console.WriteLine("price: " + price);
                        return true;
                    }

            }
            return false;
        }

        public void ShowAllProducts()
        {
            Console.WriteLine("\n***The list all products***");
            if(productsArr != null) 
                foreach (Product productDetail in productsArr) 
                {
                    Console.WriteLine($"name: {productDetail.GetProductName()} price: {productDetail.GetPrice()}");
                }
        }


        public void ShowAllBuyers()
        {
            Console.WriteLine("\n***Show all buyers detail***");
            int index = 1;
            if (buyers != null)
                foreach (UserBuyer buyer in buyers)
                {
                    if (buyer != null)
                    {
                        Console.WriteLine($"{index} {buyer.ToString()} ");
                        buyer.ToStringAllProducts();
                        Console.WriteLine();
                        index++;
                    }
                    else
                        break;
                }
        }
    }
}