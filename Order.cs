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
        private int totalPrice;
        private UserSeller sellerDetails;

        public Order(int _totalPrice)
        {
            this.totalPrice = _totalPrice;
        }
    }
}
