using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp
{
    internal class StringHandler
    {
        public static bool IsNumeric(string number)
        {
            return number.All(char.IsNumber);
        }
    }
}
