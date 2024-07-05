using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace task_2
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            const string programName = "E-commerce Project\nSubmitted by Noa-Yarin Levi and Chen Brown";
            Manager manager = new Manager(programName);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(programName + "\n");
            Console.ResetColor();

            const int EXIT = 9;
            int userSelection = 0;

            InitialData(manager);

            while (userSelection != EXIT)
            {
                Console.WriteLine();
                Console.WriteLine("---------------Menu----------------\n");
                Console.WriteLine("Choose one of the following options:");
                Console.WriteLine("(1) Add new buyer");
                Console.WriteLine("(2) Add new seller");
                Console.WriteLine("(3) Add product for seller");
                Console.WriteLine("(4) Add product to shopping cart");
                Console.WriteLine("(5) Pay order");
                Console.WriteLine("(6) Show buyers details");
                Console.WriteLine("(7) Show sellers details");
                Console.WriteLine("(8) Compare between two customers");
                Console.WriteLine("(9) EXIT");
                Console.Write("\nEnter your choice: ");
                
                    userSelection = int.Parse(Console.ReadLine());
               
                switch (userSelection)
                {
                    case 1:
                        AddBuyer(manager);
                        break;
                    case 2:
                        AddSeller(manager);
                        break;
                    case 3:
                        AddProductToSeller(manager);
                        break;
                    case 4:
                        AddProductToCart(manager);
                        break;
                    case 5:
                        Payment(manager);
                        break;
                    case 6:
                        manager.ShowAllBuyers();
                        break;
                    case 7:
                        manager.ShowAllSellers();
                        break;
                    case 8:
                        CompareBuyers(manager);
                        break;
                    case 9:
                        Console.WriteLine("Goodbye :) ");
                        break;
                    default:
                        Console.WriteLine("Invalid option! try again");
                        break;
                }
            }
        }

        private static void InitialData(Manager manager)
        {
            Address addr1 = new Address("abc", 124, "Netanya", "ISR");

            manager.AddUserBuyer("tom", "Tm54885!!", addr1);
            manager.AddUserBuyer("tomy", "5@4885!", addr1);

            manager.AddUserSeller("chen", "15@4885!", addr1);
            manager.AddUserSeller("alex", "54885!@", addr1);

            Category category =new Category();
            category.SetCategoryNameByIndex(1);
            Category category1 = new Category();
            category1.SetCategoryNameByIndex(2);

            manager.AddNewProduct(new Product("Table", 54, category), "chen");
            manager.AddNewProduct(new Product("picture", 154, category1), "chen");
            manager.AddNewProduct(new Product("monitor", 254, category), "alex");

            manager.AddProductToCart("tom", "alex", "monitor",true);
            manager.AddProductToCart("tom", "chen", "picture", false);
            manager.AddProductToCart("tomy", "chen", "table", false);

            //for only test
            manager.PaymentCart("tom");
            manager.AddProductToCart("tom", "chen", "table", true);
            manager.PaymentCart("tom");
        }


        private static void AddBuyer(Manager manager)
        {
            try
            {
                string name = NameOfUser();
                Console.WriteLine("Enter password:");
                string password = Console.ReadLine();
                Address buyerAddr = GetAddress();
                bool isAdded = manager.AddUserBuyer(name, password, buyerAddr);
                manager.AddUserBuyer(name, password, buyerAddr);
                if (isAdded && buyerAddr != null && password != "" && name != "")
                {
                    Console.WriteLine("\nBuyer successfully added!");
                }
                else
                {
                    Console.WriteLine("\nBuyer not added, try again");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }

        private static void AddSeller(Manager manager)
        {

            try
            {
                string name = NameOfUser();
                Console.WriteLine("Enter password:");
                string password = Console.ReadLine();
                Address sellerAddr = GetAddress();
                bool isAdded = manager.AddUserSeller(name, password, sellerAddr);
                if (isAdded && sellerAddr != null && password != "" && name != "")
                {
                    Console.WriteLine("\nBuyer successfully added!");
                }
                else
                {
                    Console.WriteLine("\nBuyer not added, try again");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }

        private static Address GetAddress()
        {
            int counter = 0;
            Address address = new Address();
            do 
            {
                try
                {
                    switch (counter)
                    {
                        case 0:
                            Console.WriteLine("Enter street:");
                            address.Street = Console.ReadLine();
                            counter++;
                            break;
                        case 1:
                            Console.WriteLine("Enter street number:");
                            address.NumberOfStreet = int.Parse(Console.ReadLine());
                            counter++;
                            break;
                        case 2:
                            Console.WriteLine("Enter city name:");
                            address.City = Console.ReadLine();
                            counter++;
                            break;
                        case 3:
                            Console.WriteLine("Enter country name:");
                            address.Country = Console.ReadLine();
                            counter++;
                            break;
                    }
                }    
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (counter < 4);

            return address;
        }


        static void AddProductToSeller(Manager manager)
        {
            try
            {
                Console.Write("Enter seller name: ");
                string sellerName = Console.ReadLine();
                Console.Write("Enter product name: ");
                string name = Console.ReadLine().ToLower();
                Console.Write("Enter product price: ");
                int price = int.Parse(Console.ReadLine());
                Category category = manager.AddCategory();
                if (category != null)
                {
                    manager.AddNewProduct(new Product(name, price, category), sellerName);
                    Console.WriteLine("\nProduct successfully added!");
                }
                else
                {
                    Console.WriteLine("\nProduct not added");
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine($"An error occurred: Fields are empty");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }


        static void AddProductToCart(Manager manager)
        {
            try
            {
                bool isAdded = false;
                Console.Write("Enter a buyer name: ");
                string buyerName = Console.ReadLine();
                Console.Write("Enter a seller name: ");
                string sellerName = Console.ReadLine();
                Console.Write("Enter a product name: ");
                string productName = Console.ReadLine().ToLower();
                Console.Write("Do you want add a special package? [Yes / No]: ");
                if (Console.ReadLine().ToLower() == "yes")
                {
                    Console.Write("You have to pay another NIS 20 for a special package");
                    isAdded = manager.AddProductToCart(buyerName, sellerName, productName, true);
                }
                else
                {
                    isAdded = manager.AddProductToCart(buyerName, sellerName, productName, false);
                }
                Console.WriteLine(isAdded ? "\nProduct successfully added!" : "\nProduct not added");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }

        static void CompareBuyers(Manager manager)
        {
            try
            {
                Console.Write("Enter the first name of customer: ");
                string buyer1 = Console.ReadLine();
                Console.Write("Enter the second name of customer: ");
                string buyer2 = Console.ReadLine();
                manager.ComareBuyesShopingCart(buyer1, buyer2);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Payment(Manager manager)
        {
            try
            {
                string name = NameOfUser();
                if (!manager.PaymentCart(name))
                {
                    Console.WriteLine("\nInvalid name");
                }
                else
                {
                    Console.WriteLine("\nOrder completed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }

        static string NameOfUser()
        {
            Console.Write("Enter name of user: ");
            return (Console.ReadLine()).ToLower();
        }
    }
}
