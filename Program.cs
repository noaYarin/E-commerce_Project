using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string programName = "Commercial";
            Manager manager = new Manager(programName);
            const int EXIT = 8;
            int userSelection = 0;

            //initiateData(manager);

            while (userSelection != EXIT)
            {
                Console.WriteLine();
                Console.WriteLine("---------Menu---------");
                Console.WriteLine("Choose one of the following options:");
                Console.WriteLine("(1) Add new buyer");
                Console.WriteLine("(2) Add new seller");
                Console.WriteLine("(3) Add product for seller");
                Console.WriteLine("(4) Add product to shopping cart");
                Console.WriteLine("(5) Pay order");
                Console.WriteLine("(6) Show buyers details");
                Console.WriteLine("(7) Show sellers details");
                Console.WriteLine("(8) EXIT");
                Console.Write("Enter your choice: ");
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
                        PayOrder(manager);
                        break;
                    case 6:
                        manager.ShowAllBuyers();
                        break;
                    case 7:
                        // Show all sellers
                        break;
                    case 8:
                        Console.WriteLine("Goodbye :) ");
                        break;
                    default:
                        Console.WriteLine("Invalid option! try again");
                        break;

                }
            }
        }

        private static void AddBuyer(Manager manager)
        {
            string name =NameOfUser();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            Address buyerAddr = GetAddress();
            if (manager.AddBuyer(name, password, buyerAddr))
            {
                Console.WriteLine("Buyer successfully added!");
            }
        }

        private static void AddSeller(Manager manager)
        {
            string name = NameOfUser();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            Address sellerAddr = GetAddress();
            if(manager.AddSeller(name, password, sellerAddr)){
                    Console.WriteLine("Seller successfully added!");
            }
        }

        private static Address GetAddress()
        {
            Console.WriteLine("Enter street:");
            string street = Console.ReadLine();
            Console.WriteLine("Enter street number:");
            int streetNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter city:");
            string city = Console.ReadLine();
            Console.WriteLine("Enter country:");
            string country = Console.ReadLine();

            return new Address(street, streetNumber, city, country);
        }

        static void AddProductToSeller(Manager manager) {
            Console.WriteLine("Enter product name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter product price:");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter seller name:");
            string sellerName= Console.ReadLine();
            manager.AddProductToSeller(name, price,sellerName);
        }

        static void AddProductToCart(Manager manager)
        {
            string name = NameOfUser();
            Console.Write("Enter a product name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter the product price: ");
            int productPrice = int.Parse(Console.ReadLine());
            Console.Write("Do you want add a special package? [Yes / No]: ");
            string specialBoxStr = Console.ReadLine();
            bool isSpecialBox = false;
            int extraPrice = 0;
            if (specialBoxStr == "yes")
            {
                isSpecialBox = true;
                Console.Write("How much is it to add a package box? ");
                extraPrice = int.Parse(Console.ReadLine());
            }

            else if (specialBoxStr == "no")
            {
                isSpecialBox = false;
            }
            manager.AddProductToCart(new Product(productName, productPrice, isSpecialBox, extraPrice), name); 
        }

        static void PayOrder(Manager manager)
        {
            string name = NameOfUser();
            if (!manager.payOrderAllCart(name))
            {
                Console.WriteLine("Invalid name");
            }
               
        }

        static void initiateData(Manager manager)
        {
            //Template Data
            Address addr1 = new Address("Zamenhof", 3, "Netanya", "ISR");
            manager.AddBuyer("chen", "12345", addr1);
            Address addr2 = new Address("Kikar HaAtsmaut", 34, "Netanya", "ISR");
            manager.AddBuyer("ben", "12345", addr2);
            Address addr3 = new Address("Kikar HaAtsmaut", 34, "Netanya", "ISR");
            manager.AddBuyer("aviv", "12345", addr3);

            manager.AddProductToCart(new Product("table", 12, false, 0), "chen"); 
            manager.AddProductToCart(new Product("milk", 76, true, 45), "chen");
            manager.AddProductToCart(new Product("keyboard", 76, true, 65), "ben");
        }


        static string NameOfUser()
        {
            Console.Write("Enter name :");
            string name = Console.ReadLine();
            return name.ToLower();
        }
    }
}
