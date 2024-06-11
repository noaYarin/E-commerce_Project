using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class ProductExtraFields : Product
    {
        protected bool hasSpecialBox;
        protected int extraPrice;

        public ProductExtraFields(string name, int price, Category category, bool _hasSpecialBox,int _extraPrice) : base(name,price,category){
            this.hasSpecialBox = _hasSpecialBox;
            this.extraPrice = _extraPrice;
        }

        public bool GetHasSpecialBox() { return hasSpecialBox; }
        public int GetExtraPrice() { return extraPrice; }

        public override string ToString()
        {
            base.ToString();
            return $"Special box: {hasSpecialBox}, Extra price: {extraPrice}";
        }
    }
}
