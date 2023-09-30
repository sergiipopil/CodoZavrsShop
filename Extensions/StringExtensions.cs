using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Extensions
{
    public static class StringExtensions
    {
        public static string GetUserName(this string str)
        {
            return $"Hi {str}";
        }
    }
}
