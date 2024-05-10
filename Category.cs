using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Category
    {
        private int code;
        private string name;

        public Category(int _code, string _name)
        {
            SetCode(_code);
            this.name = _name;
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

    }
}
