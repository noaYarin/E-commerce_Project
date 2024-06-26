﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace task_2
{
    internal class ProductExtraFields : Product
    {
        protected bool hasSpecialBox;
        protected const int extraPrice=20;

        public ProductExtraFields(int id,string name, int price, Category category, bool _hasSpecialBox) : base(id,name,price,category){
            this.hasSpecialBox = _hasSpecialBox;
          }

        public bool GetHasSpecialBox() { return hasSpecialBox; }
        public int GetExtraPrice() { return extraPrice; }

        public override string ToString()
        {
            string specialBox = hasSpecialBox ? "Yes" : "No";
            string price = hasSpecialBox ? $", Extra price: {extraPrice}" : "";
            string baseString = base.ToString();
            return $"{baseString}\t\t,Special box: {specialBox} {price}\n";
        }
    }
}
