﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Seller : User
    {
        Product[] products;
        private int size = 2;
        private int productLogicSize = 0;

        public Seller(string name, string password, Address address) : base(name, password, address)
        {
            products = new Product[size];
        }

        public Seller(User others) : base(others)
        {
            products = new Product[size];
        }

        public Seller() : base() { }


        public Product GetProduct(string productName)
        {
            foreach (Product product in products)
            {
                if (product != null)
                {
                    if (product.Name.ToLower() == productName)
                        return product;
                }
                else return null;
            }
            return null;
        }

        public bool SetProduct(Product productDetails)
        {
            Product[] tempNewProducts;
            if (productLogicSize == products.Length)
            {
                tempNewProducts = new Product[products.Length * size];
                products.CopyTo(tempNewProducts, 0);
                products = tempNewProducts;

            }
            products[productLogicSize] = productDetails;
            productLogicSize++;
            return true;
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

    }
}
