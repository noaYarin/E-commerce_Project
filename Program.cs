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
                        manger.addBuyer("dani","234543",);
                        break;
                    case 2:
                       //
                        break;
                    case 3:
                      //
                        break;
                    case 4:
                       //
                        break;
                    case 5:
                        //
                        break;
                    case 6:
                        //
                        break;
                    case 7:
                        //
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

        //static UserBuyer createUser()
       // {}
    }
}
