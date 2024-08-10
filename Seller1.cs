using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using static task_2.Category;

namespace task_2
{
    internal class Seller : User
    {
        private List<Product> products;
        private int size = 2;

        public Seller(string name, string password, Address address) : base(name, password, address)
        {
            products = new List<Product>(size); 
        }

        public Seller(User others) : base(others)
        {
            products = new List<Product>(size); 
        }

        public Seller() : base() { }


        public Product GetProduct(string productName)
        {
            foreach (Product product in products)
            {
                if (product != null && product.Name.ToLower() == productName.ToLower())
                {
                    return product;
                }
            }
            return null;

        }

        public void SetProduct(Product productDetails)
        {
            products.Add(productDetails);
        }

        public void ImportProductFromString(string productData)
        {
           string[] productDetails = productData.Split(',');
            if (productDetails.Length == 3)
            {
                string productName = productDetails[0].Trim();
                if (!int.TryParse(productDetails[1].Trim(), out int price))
                {
                    throw new ArgumentException("Invalid price format.");
                }
                    string categoryString = productDetails[2].Trim();
                    Category category = new Category();
                    int categoryIndex = category.FindCategoryIndexByName(categoryString);
                    category.SetCategoryNameByIndex(categoryIndex);
                   Product product = new Product(productName, price, category);
                SetProduct(product);
            }
            else
            {
                throw new ArgumentException("Invalid product data format.");
            }
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

        public override string ToString()
        {
            string baseString = base.ToString();
            foreach (var productDetail in products)
            {
                if (productDetail != null)
                    baseString += productDetail.ToString();
                else
                    break;
            }
            return baseString;
        }

        public int GetProductCount()
        {
            return products.Count;
        }

        public List<Product> GetProducts()
        {
            return products;
        }
    }
}
