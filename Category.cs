using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Category
    {
        private int code;
        private CategoriesList name;
        public enum CategoriesList{
            Children=1,
            Electricity,
            Office,
            Clothes
        }

        public Category(){ }
        public Category(int _code){
             SetCode(_code);
          }

        private bool SetCode(int code)
        {
            if (code <= 0)
            {
                Console.WriteLine("Invaild code");
                return false;
            }
            this.code = code;
            return true;
        }

        public string[] GetCategoryNames()
        {
            return Enum.GetNames(typeof(CategoriesList));
        }

        public void SetCategoryNameByIndex(int index)
        {
            string[] categoryNames = GetCategoryNames();
            if (index >= 0 && index <= categoryNames.Length)
            {
                name = (CategoriesList)index;
            }
        }

        public CategoriesList GetCategoryName()
        {
            return name;
        }

    }
}
