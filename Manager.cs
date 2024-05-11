using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Manager
    {
        private UserSeller[] sellersArr;
        private UserBuyer[] usersArr;
        private Product[] productsArr;
        private string name;
        private int index = 0;

        public Manager(string _name)
        {
            this.name = _name;
        }

 
        public bool addMyProduct(Product p)
        {
            Product[] newProduct;
            if(productsArr == null)
            {
                newProduct = new Product[1];
                newProduct[0] = new Product(p.GetProductName(), p.GetPrice()); 
            }

            else
            {
                newProduct = new Product[productsArr.Length+1];
                productsArr.CopyTo(newProduct, 0);
                newProduct[productsArr.Length] = new Product(p.GetProductName(), p.GetPrice());
            }
            productsArr = newProduct;

            return true; 
        }


        public bool addBuyer(string name, string password, Address address)
        {
            const int size = 2;
            UserBuyer tempBuyer =new UserBuyer();
            bool isValid = tempBuyer.SetBuyer(name, password, address);
            if (!isValid) 
            {
                Console.WriteLine("Invalid value");
                return false;
            }
            multiplyBy2(ref usersArr,size);
            usersArr[index]=new UserBuyer(name, password, address);
            index++;
            return true;
        }

        //TO DO - find the type of parameter and comlete function
        public void multiplyBy2(ref UserBuyer[] usersArr, int size)
        {
    
            if (usersArr == null)
            {
              
            }
            else
            {
               
               // usersArr *= size;
            }
        }

    }
}