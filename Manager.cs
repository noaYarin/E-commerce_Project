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
        private int buyersLogSize;
        private string name;
        private int size = 2;
        public Manager(string _name)
        {
            this.name = _name;
            buyersLogSize = 0;
            buyers = new UserBuyer[size];
            sellersLogSize = 0;
            sellers = new UserSeller[size];
        }

        public bool addBuyer(string name, string password, Address address)
        {
            UserBuyer newBuyer = new UserBuyer();
            bool isValid = newBuyer.SetBuyer(name, password, address);
            if (!isValid)
            {
                Console.WriteLine("Invalid value");
                return false;
            }

            if (buyersLogSize == buyers.Length)
            {
                UserBuyer[] buyers2 = new UserBuyer[buyers.Length * 2];
                for (int i = 0; i < buyers.Length; i++)
                {
                    buyers2[i] = new UserBuyer(buyers[i]);
                }
                buyers = buyers2;
            }

            buyers[buyersLogSize] = newBuyer;
            buyersLogSize++;
            return true;
        }
    }
}