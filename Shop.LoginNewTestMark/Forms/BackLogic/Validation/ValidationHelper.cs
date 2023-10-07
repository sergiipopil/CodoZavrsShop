using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.LoginNewTestMark.Forms.BackLogic.Validation
{
    public static class ValidationHelper
    {
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;

            if (password.Length < 8) return false;

            return password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit) &&
                   password.Any(c => !char.IsLetterOrDigit(c));
        }
    }
}
