using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Validation
    {
        public bool IsContainDigit(string str)
        {
            foreach (char ch in str)
                if (ch >= '0' && ch <= '9')
                    return true;
            return false;
        }


        public bool IsValidPassword(string password)
        {
            bool hasSpecialChar = false;
            string specialSigns = "!@#&$?";
            for (int i = 0; i < password.Length; i++)
            {
                for (int j = 0; j < specialSigns.Length; j++)
                {
                    if (password[i] == specialSigns[j])
                    {
                        hasSpecialChar = true;
                        break;
                    }
                }
            }

            if (password != null && password.Length >= 4 && hasSpecialChar)
            {
                Console.WriteLine("Strong password");
                return true;
            }
            Console.WriteLine("Password should to be at least 4 charecters including a special character: {! @ # & $ ?}");
            return false;
        }
    }
}
