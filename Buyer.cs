using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Buyer : User
    {
        private Order[] orders;
        Product[] products;
        private int logicSize = 0;
        private int productSizeLogic = 0;
        private int size = 2;

        public Buyer(string name, string password, Address address):base(name, password, address) 
        {
            this.name = name;
            this.password = password;
            this.address = address;
            products = new Product[size];
        }

        public Buyer(User others):base(others) 
        {
            products = new Product[size];
        }
        public Buyer():base() { }


        public bool SetNewBuyer(string name, string password, Address address) // To Do with copy costructor - Buyer buyer
        {
            if(SetUser(name, password, address))
                return true;
            return false;
        }


        public bool SetProduct(Product productDetails)
        {
            Product[] tempNewProducts;
            if (productSizeLogic == products.Length)
            {
                tempNewProducts = new Product[products.Length * size];
                products.CopyTo(tempNewProducts, 0);
                products = tempNewProducts;

            }
            products[productSizeLogic] = productDetails;
            productSizeLogic++;
            return true;
        }

        public void ToStringHistoryProducts()
        {
            if (orders != null)
            {
                Console.WriteLine("\tHistrory shopping:");
                foreach (var order in orders)
                {
                    Console.WriteLine(order.ToString());
                    order.HistroyCart();
                }
            }
        }

        public bool RemoveAllCartProducts()
        {
            for (int i = 0; i < products.Length; i++)
            {
                products[i] = null;
            }
            logicSize = 0;
            return true;
        }


        public int GetPriceCart()
        {
            int priceCart = 0;
            if (products != null)
                foreach (Product productDetail in products)
                {
                    priceCart += productDetail.GetPrice();
                }
            return priceCart;
        }

        public bool SetOrderArr() 
        {
            Order[] newOrder;

            if (orders == null)
            {
                orders = new Order[1];
            }
            else
            {
                newOrder = new Order[orders.Length + 1];
                orders.CopyTo(newOrder, 0);
                orders = newOrder;
            }

            this.orders[orders.Length - 1] = new Order(products, products.Length); 
            return true;
        }

        public string ToString()
        {
            return $"name: {name} password {password}";
        }

    }
}
