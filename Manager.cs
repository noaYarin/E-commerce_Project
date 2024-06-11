using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Manager
    {
        private Buyer[] buyers; 
        private Seller[] sellers; 

        private string name;
        private int sellersLogSize=0;
        private int buyersLogSize=0;
        private const int size = 2;


        public Manager(string _name)
        {
            buyers = new Buyer[size];
            sellers = new Seller[size];
            this.name = _name;
        }

       
        public bool AddUserBuyer(string name, string password, Address address)
        {
            User newUser = new User(name, password, address); 
            bool isNameNotExist = checkUserName(name);
            if (isNameNotExist)
            {
                Buyer[] tempNewBuyers;
                Buyer newBuyer = new Buyer(newUser);
                if (buyersLogSize == buyers.Length)
                {
                    tempNewBuyers = new Buyer[buyers.Length * 2];
                    buyers.CopyTo(tempNewBuyers, 0);
                    buyers = tempNewBuyers;
                }
                buyers[buyersLogSize] = newBuyer;
                buyersLogSize++;
                
            }
            return true;
        }

        public bool AddUserSeller(string name, string password, Address address)
        {
            User newUser = new User(name, password, address);
            bool isNameNotExist = checkUserName(name);
            if (isNameNotExist)
            {
                Seller[] tempNewBuyers;
                Seller newSeller = new Seller(newUser);
                if (sellersLogSize == sellers.Length)
                {
                    tempNewBuyers = new Seller[sellers.Length * 2];
                    sellers.CopyTo(tempNewBuyers, 0);
                    sellers = tempNewBuyers;
                }
                sellers[sellersLogSize] = newSeller;
                sellersLogSize++;

            }
            return true;
        }


       public void PrintAllProductSeller()
       {
            foreach(var seller in sellers)
            {
                Console.WriteLine(seller.ToString());
            }
       }


        public bool AddProductToCart(string buyerName, string sellerName, string productName) 
        {
            
            foreach (var buyer in buyers) 
            {
                if(buyer.GetBuyerName() == buyerName)
                {
                    foreach(var seller in sellers)
                    {
                        if(seller.GetBuyerName() == sellerName)
                        {
                            buyer.SetProduct(seller.GetProduct(productName));
                        }
                    }
                }

            }
            
            return false;
        }

        public bool AddNewProduct(Product product, string name)
        {           
            foreach (var seller in sellers)
            {

                if (checkSellerName(seller, name)) 
                {
                    seller.SetProduct(product);
                    return true;
                }
            }
            return false;
        }


        public bool PaymentCart(string name)
        {
            foreach (var buyer in buyers)
            {
                if (checkBuyerName(buyer, name))
                {
                    buyer.SetOrderArr(); 
                    buyer.RemoveAllCartProducts();
                    return true;
                }
            }
            return false;
        }


        public void ShowAllBuyers()
        {
            Console.WriteLine("\n***Show all buyers details***");
            if (buyers[0] != null)
            {
                int index = 1;
                foreach (var buyer in buyers)
                {
                    if (buyer == null)
                    {
                        break;
                    }
                    Console.WriteLine($"{index}) {buyer.ToString()} ");
                    //buyer.ToStringAllProducts();
                    Console.WriteLine();
                    buyer.ToStringHistoryProducts();
                    Console.WriteLine();
                    index++;
                }
            }
            else
            {
                Console.WriteLine("\nNo buyers to display.");
            }
        }


        public void ShowAllSellers()
        {
            Console.WriteLine("\n***Show all sellers details***");
            if (sellers[0] != null)
            {
                int index = 1;
                foreach (var seller in sellers)
                {
                    if (seller == null)
                    {
                        break;
                    }
                    Console.WriteLine($"{index}) {seller.ToString()} ");
                    //seller.ToStringAllProducts();
                    Console.WriteLine();
                    index++;
                }
            }
            else
            {
                Console.WriteLine("\nNo sellers to display.");
            }
        }



        private bool checkUserName(string name)
        {
            foreach (var seller in sellers)
            {
                if (checkSellerName(seller, name))
                {
                    Console.WriteLine("Name already taken, try another name");
                    return false;
                }
            }

            foreach (var buyer in buyers)
            {
                if (checkBuyerName(buyer, name))
                {
                    Console.WriteLine("Name already taken, try another name");
                    return false;
                }
            }

            return true;
        }

        public bool checkBuyerName(Buyer buyer, string name)
        {
            return buyer != null && buyer.GetBuyerName() == name ? true : false;
        }

        public bool checkSellerName(Seller buyer, string name)
        {
            return buyer != null && buyer.GetBuyerName() == name ? true : false;
        }


    }
}