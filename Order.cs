using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Order:ICloneable 
    {
        private List<Product> allProducts;
        private float totalPrice = 0;
        private User buyerDetails;
        private readonly int orderNum=0;
        private static int lastOrderNum = 10000000;

        private static int LastOrderNum
        {
            get { return lastOrderNum; }
            set { lastOrderNum = value; }
        }
        public object Clone()
        {
            LastOrderNum--;
            return new Order(allProducts.ToArray(), allProducts.Count, new Buyer());
        }

        public float TotalPrice 
        {
            get { return totalPrice; }
            set { totalPrice = SetOrderPrice(); }
        }


        public List<Product> GetAllProducts()
        {
            return allProducts;
        }

        public Order(Product[] products, int cart_size, User user)
        {
            SetCheckOut(cart_size, products);
            totalPrice = SetOrderPrice();
            buyerDetails = user;
            orderNum = LastOrderNum++; 
        }


        private void SetCheckOut(int cart_size, Product[] cartProducts)
        {
            this.allProducts = new List<Product>(cart_size); 
              for (int i = 0; i < cart_size; i++)
            {
                bool hasSpecialBox = cartProducts[i] is ProductExtraFields productExtra ? productExtra.GetHasSpecialBox() : false;
                if (cartProducts[i] != null)
                {
                    this.allProducts.Add(new ProductExtraFields(cartProducts[i].Id, cartProducts[i].Name, cartProducts[i].Price, cartProducts[i].Category, hasSpecialBox)); 
                }
            }
        }

      public int GetOrderNum()
        {
           return orderNum;
        }

        private float SetOrderPrice()
        {
            float price = 0;
            foreach (ProductExtraFields product in allProducts)
            {
                if (product != null)
                {
                    if (product.GetHasSpecialBox())
                    {
                        price += product.GetExtraPrice();
                    }
                    price += product.Price;
                }
                else 
                    break;
            }
            return price;
        }

        public void HistroyCart()
        {
            foreach (var item in allProducts)
            {
                if(item != null)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        public override string ToString()
        {
            string resProducts = "";
            foreach (Product product in allProducts)
            {
                if(product == null) 
                {
                    break;
                }
                resProducts += product.ToString();
            }
            return $"\tOrder number #{orderNum},total price: {TotalPrice}\n {resProducts}\n ";
        }
    }
}
