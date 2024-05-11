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
            Manager manger = new Manager(programName);
            const int EXIT = 8;
            int userSelection = 0;

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
                        //manger.addBuyer("dani","234543",);
                        break;
                    case 2:
                       //
                        break;
                    case 3:
                      //
                        break;
                    case 4:
                        // Add product to shopping cart
                        AddProductToCart(manger);
                        break;
                    case 5:
                        // Pay order
                        PayOrder(manger);
                        break;
                    case 6:
                        //
                        break;
                    case 7:
                        // for only tests
                        manger.ShowAllProducts();
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


        static void PayOrder(Manager manager)
        {
            Console.WriteLine("What name of the buyer: ");
            string name = Console.ReadLine();
            manager.payOrderAllCart("chen");
        }

        static void AddProductToCart(Manager manger)
        {
            Console.WriteLine("\nYou choose add prodct to shopping cart");
            Console.Write("Enter a product name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter the product price: ");
            int productPrice = int.Parse(Console.ReadLine());
            Console.Write("Enter which type of category from this list: [Kids, Electronics, Offices, Cloths]: ");
            string category = Console.ReadLine();
            Console.Write("Do you want add a special package? [Yes / No]: ");
            string specialBoxStr = Console.ReadLine();
            bool isSpecialBox=false;
            int extraPrice=0;
            if (specialBoxStr == "yes")
            {
                isSpecialBox = true;
                Console.Write("how much is it to add a package box? ");
                extraPrice = int.Parse(Console.ReadLine());
            }
               
            else if(specialBoxStr == "no")
                isSpecialBox= false;

            manger.addMyProduct(new Product(productName, productPrice)); // To Do fix constructor
        }

        //static UserBuyer createUser()
        // {}
    }
}
