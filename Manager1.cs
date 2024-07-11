﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace task_2
{
    internal class Manager
    {
        private Buyer[] buyers;
        private Seller[] sellers;

        private string name;
        private int sellersLogSize = 0;
        private int buyersLogSize = 0;
        private const int size = 2;


        public Manager(string _name)
        {
            buyers = new Buyer[size];
            sellers = new Seller[size];
            this.name = _name;
        }

        
        public bool AddUserBuyer(string name, string password, Address address)
        {
            bool isNameNotExist = checkUserName(name); 
            if (isNameNotExist)
            {
                Buyer[] tempNewBuyers;
                try
                {
                    Buyer newBuyer = new Buyer(name, password, address);
                    if (buyersLogSize == buyers.Length)
                    {
                        tempNewBuyers = new Buyer[buyers.Length * 2];
                        buyers.CopyTo(tempNewBuyers, 0);
                        buyers = tempNewBuyers;
                    }
                    buyers[buyersLogSize] = newBuyer;
                    buyersLogSize++;
                    return true;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false; 
        }

        public bool AddUserSeller(string name, string password, Address address)
        {
            bool isNameNotExist = checkUserName(name); 
            if (isNameNotExist)
            {
                Seller[] tempNewBuyers;
                Seller newSeller = new Seller(name, password, address);
                if (sellersLogSize == sellers.Length)
                {
                    tempNewBuyers = new Seller[sellers.Length * 2];
                    sellers.CopyTo(tempNewBuyers, 0);
                    sellers = tempNewBuyers;
                }
                sellers[sellersLogSize] = newSeller;
                sellersLogSize++;
                return true;
            }
            return false;
        }


        public void PrintAllProductSeller()
        {
            foreach (var seller in sellers)
            {
                Console.WriteLine(seller.ToString());
            }
        }


        public bool AddProductToCart(string buyerName, string sellerName, string productName,bool hasSpecialBox)
        {
            foreach (var buyer in buyers)
            {
                if (buyer!=null && buyer.Name == buyerName)
                {
                    foreach (var seller in sellers)
                    {
                        if (seller.Name == sellerName)
                        {
                            if (buyer.SetProduct(seller.GetProduct(productName),hasSpecialBox))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
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
                if (seller!=null && seller.Equals(name))  
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
                if (buyer.Equals(name))  
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
            return buyer != null && buyer.Name == name ? true : false;
        }

        public bool checkSellerName(Seller seller, string name)
        {
            return seller != null && seller.Name == name ? true : false;
        }

        public Category AddCategory()
        {
            Category category = new Category();
            DisplayCategories(category);
            int index = int.Parse(Console.ReadLine());
            bool isValidChoice = category.SetCategoryNameByIndex(index);
            return !isValidChoice ? null : category;
        }

        public void DisplayCategories(Category category)
        {
            string[] categories = category.GetCategoryNames();

            Console.WriteLine("Please choose a category by number:");
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {categories[i]}");
            }
        }


        public void ComareBuyesShopingCart(string buyer1, string buyer2)
        {
            if(FindBuyer(buyer1) != null && FindBuyer(buyer2) != null)
            {
                Buyer b1 = FindBuyer(buyer1);
                Buyer b2 = FindBuyer(buyer2);
                int res = b1.CompareTo(b2);
                if (res == 0)
                    Console.WriteLine("the shopping cart price is the same for both buyers");
                else if (res == 1)
                    Console.WriteLine($"The shopping cart of {b1.Name} bigger than {b2.Name}");
                else
                    Console.WriteLine($"The shopping cart of {b2.Name} bigger than {b1.Name}");
            }

            else
            {
                Console.WriteLine("Buyer not exist");
            }
        }


        public void ResorteShoppingCart(string buyer1)
        {
            if( FindBuyer(buyer1) != null)
            {
                Buyer buyer = FindBuyer(buyer1);
                buyer.ShowShoppingCartDetail();
                Console.Write("Enter a price: ");
                try
                {
                    float restoreByPrice = float.Parse(Console.ReadLine());
                    Product[] OrderClone = buyer.OrderClone(restoreByPrice);
                    buyer.SetProductFromHistory(OrderClone);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Buyer not exist");
            }
        }


        private Buyer FindBuyer(string name)
        {
            foreach (Buyer buyer in buyers)
            {
                if (buyer.Name == name)
                    return buyer;
            }
            return null;
        }

    }
}