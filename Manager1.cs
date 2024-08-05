﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace task_2
{
    internal class Manager
    {
        private List<Buyer> buyers;
        private List<Seller> sellers;
        private string name;
        private const int size = 2;

        public Manager(string _name)
        {
            buyers = new List<Buyer>(size); 
           sellers = new List<Seller>(size); 
           this.name = _name;
        }

        public static Manager operator +(Manager manager, Buyer newBuyer)
        {
            if (manager.buyers.Count == manager.buyers.Capacity)
            {
                manager.buyers.Capacity *= 2; 
            }
            manager.buyers.Add(newBuyer); 
            return manager;
        }

        public static Manager operator +(Manager manager, Seller newSeller)
        {
            if (manager.sellers.Count == manager.sellers.Capacity)
            {
                manager.sellers.Capacity *= 2; 
            }
            manager.sellers.Add(newSeller); 
            return manager;
        }

        public void AddUserBuyer(string name, string password, Address address)
        {
            bool isNameNotExist = checkUserName(name);
            if (isNameNotExist)
            {
                try
                {
                    name = name.ToLower();
                    Buyer newBuyer = new Buyer(name, password, address);
                    Manager updatedManager = this + newBuyer;
             
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public void AddUserSeller(string name, string password, Address address)
        {
            bool isNameNotExist = checkUserName(name);
            if (isNameNotExist)
            {
                try
                {
                    Seller newSeller = new Seller(name, password, address);
                    Manager updatedManager = this + newSeller;                   
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
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


        public void AddNewProduct(Product product, string name)
        {
            foreach (var seller in sellers)
            {
                if (seller!=null && seller.Equals(name))  
                {
                    seller.SetProduct(product);
                    return;
                }
            }
            throw new Exception("Seller don't found");
        }


        public bool PaymentCart(string name)
        {
            foreach (var buyer in buyers)
            {
                if (buyer.Equals(name))  
                {
                    if (buyer.GetProductSize() == 1)
                    {
                        throw new Exception("The shopping cart needs to contains at least 2 items");
                    }
                    buyer.SetOrderArr();
                    buyer.RemoveAllCartProducts();
                    return true;
                }
            }
            return false;
        }


        public string ShowAllBuyers()
        {
            string str = "";
            if (buyers.Count > 0)
            {
                int index = 1;
                foreach (var buyer in buyers)
                {
                     if (buyer == null)
                    {
                        break;
                    }
                    str += buyer.ToString() + '\n';
                    index++;
                }
            }
            else
            {
                throw new ArgumentException("No buyers to display.");
            }
            return str;
        }


        public string ShowAllSellers()
        {
            string str = "";
            if(sellers.Count == 0)
            {
                throw new Exception("No sellers to display.");
            }
            var validSellers = sellers.Where(seller => seller != null)
                                         .OrderByDescending(seller => seller.GetProductCount())
                                         .ToList();

            if (validSellers.Count>0)
            {
                int index = 1;
                foreach (var seller in validSellers)
                {
                    str += seller.ToString() + "\n";
                    index++;
                }
            }
            else
            {
                throw new Exception("No sellers to display.");
            }
            return str;
        }


        private bool checkUserName(string name)
        {
            foreach (var seller in sellers)
            {
                if (checkSellerName(seller, name))
                {
                    Console.WriteLine("Name already taken, try another name");
                    throw new Exception("Name already taken, try another name");
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

        public Category AddCategory(int index)
        {
            Category category = new Category();
            DisplayCategories(category);
            //int index = int.Parse(Console.ReadLine());
            
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
                try
                {
                    int res = b1.CompareTo(b2);
                    if (res == 0)
                        Console.WriteLine("the shopping cart price is the same for both buyers");
                    else if (res == 1)
                        Console.WriteLine($"The shopping cart of {b1.Name} bigger than {b2.Name}");
                    else
                        Console.WriteLine($"The shopping cart of {b2.Name} bigger than {b1.Name}");
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


        public void ResorteShoppingCart(string buyer1)
        {
            if( FindBuyer(buyer1) != null)
            {
                Buyer buyer = FindBuyer(buyer1);
                buyer.ShowShoppingCartDetail();
                Console.Write("Enter order number: ");
                try
                {
                    float restoreByOrderNum = float.Parse(Console.ReadLine());
                    Product[] OrderClone = buyer.OrderClone(restoreByOrderNum);
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
                if (buyer.Name.ToLower() == name)
                    return buyer;
            }
            return null;
        }

    }
}