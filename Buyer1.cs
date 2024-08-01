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
        private List<Order> orders;
        private List<Product> products;
        private int size = 2;

        public Buyer(string name, string password, Address address) : base(name, password, address)
        {
            products = new List<Product>(size); 
        }

        public Buyer(User others) : base(others)
        {
            products = new List<Product>(size); 
        }
        public Buyer() : base() { }


        public bool SetProduct(Product productDetails, bool hasSpecialBox)
        {
                ProductExtraFields productExtraFields = new ProductExtraFields(productDetails.Id,productDetails.Name, 
                    productDetails.Price,productDetails.Category,hasSpecialBox);

            if (productExtraFields == null)
                throw new ArgumentException("Adding product fails");
            if (products.Count == products.Capacity)
            {
                products.Capacity *= size; 
            }
            products.Add(productExtraFields); 
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
            if (orders == null) 
            {
                orders = new List<Order>(); 
            }
            orders.Add(new Order(products.ToArray(), products.Count, new User(Name, Password, Address))); 
            return true;
        }

        public bool RemoveAllCartProducts()
        {
            products.Clear(); 
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
            if (Name == (string)obj)
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
                if(order.GetOrderNum() == restoreByPrice)
                {
                    Order p2 = (Order)order.Clone();
                    Product[] prod = p2.GetAllProducts().ToArray();
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
            return products.Count;
        }

    }
}
