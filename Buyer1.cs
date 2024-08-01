using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Buyer : User, IComparable<Buyer>
    {
        private Order[] orders;
        private Product[] products;
        private int logicSize = 0;
        private int productSizeLogic = 0;
        private int size = 2;

        public Buyer(string name, string password, Address address) : base(name, password, address)
        {
            products = new Product[size];
        }

        public Buyer(User others) : base(others)
        {
            products = new Product[size];
        }
        public Buyer() : base() { }


        public bool SetProduct(Product productDetails, bool hasSpecialBox)
        {
                ProductExtraFields productExtraFields = new ProductExtraFields(productDetails.Id,productDetails.Name, 
                    productDetails.Price,productDetails.Category,hasSpecialBox);

            if (productExtraFields == null)
                throw new ArgumentException("adding product fails");

            Product[] tempNewProducts;
            if (productSizeLogic == products.Length)
            {
                tempNewProducts = new Product[products.Length * size];
                products.CopyTo(tempNewProducts, 0);
                products = tempNewProducts;

            }
            products[productSizeLogic] = productExtraFields;
            productSizeLogic++;
            return true;
        }

        public int GetPriceCart()
        {
            int priceCart = 0;
            if (products != null)
                foreach (Product productDetail in products)
                {
                    priceCart += productDetail.Price;
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

            this.orders[orders.Length - 1] = new Order(products, products.Length, new User(Name, Password, Address));
            return true;
        }

        public bool RemoveAllCartProducts()
        {
            for (int i = 0; i < products.Length; i++)
            {
                products[i] = null;
            }
            logicSize = 0;
            productSizeLogic = 0;
            return true;
        }

      
        public override string ToString()
        {
            string baseString = base.ToString();

            foreach (Product product in products)
            {
                if (product != null)
                    baseString += product.ToString();
            }

            if (orders != null)
            {
                baseString += "\n\tHistory shopping:\n";
                foreach (Order order in orders)
                {
                    baseString += order.ToString();
                }
            }

            return baseString;
        }


        public override bool Equals(object obj)
        {
            if(Name == (string)obj)
                return true;
            else
            {
                return false;
            }
        }


        public int CompareTo(Buyer other)
        {
            float totalSumOthers = 0,totalSum = 0;

            if(other.products == null || products == null) 
            {
                throw new Exception("Shopping cart is empty");
            }
            else
            {
                    foreach (Product product in other.products)
                    {
                        if (product != null)
                        {
                            totalSumOthers += product.Price;
                        }
                    }

                    foreach (Product product in products)
                    {
                        if (product != null)
                        {
                            totalSum += product.Price;
                        }
                    }
            }

            if (totalSumOthers > totalSum)
                return -1;
            else if (totalSumOthers < totalSum)
                return 1;
            return 0;
        }


        public Product[] OrderClone(float restoreByPrice)
        {
            foreach(Order order in orders)
            {
                if(order.TotalPrice == restoreByPrice)
                {
                    Order p2 = (Order)order.Clone();
                    Product[] prod = p2.GetAllProducts();
                    return prod;
                }
            }
            return null;
        }


        public void SetProductFromHistory(Product[] productsHistory )
        {
            foreach (ProductExtraFields product in productsHistory)
            {
                if (product == null)
                {
                    break;
                }
                SetProduct(product, product.GetHasSpecialBox()); 
            }
        }

        public void ShowShoppingCartDetail()
        {
            foreach(Order order in orders)
            {
                Console.WriteLine(order.ToString());
            }
        }

        public int GetProductSize()
        {
            return this.productSizeLogic;
        }

    }
}
