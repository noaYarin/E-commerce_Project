using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Order
    {
        private Product[] allProducts;
        private float totalPrice = 0;
        private UserBuyer buyerDetails;

        public Order(UserBuyer buyer, Product[] products, int cart_size)
        {
            this.buyerDetails = buyer;
            SetCheckOut(cart_size, products);
            SetOrderPrice();
        }

       
        private void SetCheckOut(int cart_size, Product[] cartProducts)
        {
            this.allProducts = new Product[cart_size];
            for(int i = 0; i < cart_size; i++)
            {
                this.allProducts[i] = new Product(cartProducts[i]);
            }
        }


        private void SetOrderPrice()
        {
            float price = 0;
            foreach (var product in this.allProducts)
            {
                price += product.GetPrice();
            }
            this.totalPrice = price;
        }

       

        public string ToString() 
        {
            return $"\t# {buyerDetails.GetBuyerName()}: total price: {totalPrice} ";
        }

        public void HistroyCart()
        {
            foreach (var item in this.allProducts)
            {
                if(item != null)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
      
    }
}
