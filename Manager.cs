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
        private string name;
        private UserSeller[] sellers;
        private int sellersLogSize=0;
        private UserBuyer[] buyers;
        private int buyersLogSize=0;
        private const int size = 2;
        private Product[] productsArr;

        public Manager(string _name)
        {
            this.name = _name;
            buyers = new UserBuyer[size];
            sellers = new UserSeller[size];
        }


       
        public bool AddBuyer(string name, string password, Address address)
        {
            UserBuyer[] tempNewBuyers;
            UserBuyer newBuyer = new UserBuyer();

             checkUserName(name);

            bool isValid = newBuyer.SetBuyer(name, password, address);
            if (!isValid)
            {
                Console.WriteLine("Invalid values");
                return false;
            }

            if (buyersLogSize == buyers.Length)
            {
                tempNewBuyers = new UserBuyer[buyers.Length * 2];
                buyers.CopyTo(tempNewBuyers, 0);
                buyers = tempNewBuyers;
            }
            buyers[buyersLogSize] = newBuyer;
            buyersLogSize++;
            return true;
        }


        public bool AddSeller(string name, string password, Address address)
        {
            UserSeller[] tempNewSellers;
            UserSeller newSeller = new UserSeller();
            bool isNameNotExist = checkUserName(name);
            bool isValid = newSeller.SetSeller(name, password, address);
            if (!isValid || !isNameNotExist)
            {
                Console.WriteLine("Invalid values");
                return false;
            }

            if (sellersLogSize == sellers.Length)
            {
                tempNewSellers = new UserSeller[sellers.Length * 2];
                sellers.CopyTo(tempNewSellers, 0);
                sellers = tempNewSellers;
            }
            sellers[sellersLogSize] = newSeller;
            sellersLogSize++;
            return true;
        }

        public void AddProductToSeller(string name,int price,string sellerName)
        {
            foreach (var seller in sellers)
            {
                if(seller.GetSellerName()!= null && seller.GetSellerName() == sellerName) {
                    seller.AddProduct(name, price);
                }
            }

        }

        public bool AddProductToCart(Product product, string name)
        {
            foreach (var buyer in buyers)
            {
               
                if(buyer!=null && buyer.GetBuyerName() == name)
                {
                    buyer.SetProduct(product);
                    return true;
                }
            }

            return false; 
        }


        public bool payOrderAllCart(string name)
        {
            foreach (UserBuyer buyer in buyers)
            {
                if (buyer != null) 
                    if (name == buyer.GetBuyerName())
                    {
                        Console.WriteLine("price: " + buyer.GetPriceCart());
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
            Console.WriteLine("\n***Show all buyers details***");
            if (buyers[0] != null) 
            {
                int index = 1;
                foreach (var buyer in buyers)
                {
                    if (buyer == null) { 
                        break;
                    }
                    Console.WriteLine($"{index} {buyer.ToString()} ");
                    buyer.ToStringAllProducts(); 
                    Console.WriteLine();
                    index++;
                }
            }
            else
            {
                Console.WriteLine("No buyers to display."); 
            }

        }

        public void ShowAllSellers()
        {
            Console.WriteLine("\n***Show all buyers details***");
            if (sellers[0] != null)
            {
                int index = 1;
                foreach (var seller in sellers)
                {
                    if (seller == null)
                    {
                        break;
                    }
                    Console.WriteLine($"{index} {seller.ToString()} ");
                    seller.ToStringAllProducts();
                    Console.WriteLine();
                    index++;
                }
            }
            else
            {
                Console.WriteLine("No sellers to display.");
            }
        }

        private bool checkUserName(string name)
        {
            foreach (var seller in sellers)
            {
                if (seller != null && seller.GetSellerName() == name)
                {
                    Console.WriteLine("Name already taken, try another name");
                    return false;
                }
            }

            foreach (var buyer in buyers)
            {
                if (buyer != null && buyer.GetBuyerName() == name)
                {
                    Console.WriteLine("Name already taken, try another name");
                    return false;
                }
            }

            return true;
        }
    }
}