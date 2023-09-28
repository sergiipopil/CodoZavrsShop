using Shop.Classes.account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Classes.forms
{
    //  В этом классе я передаю данные в Loggin.cs где они будут сравниватся
    //  с данными в json файле
    //  ->

    internal class LoginForm
    {
        private const int MaxAttempts = 3;
        private readonly int MaxAttemptsForReset = 5;

        private int attempts;

        public LoginForm()
        {
            attempts = MaxAttempts;
        }

        public bool TryLogin()
        {
            do
            {
                Console.WriteLine("Enter your first name:");
                string firstName = Console.ReadLine();

                Console.WriteLine("Enter your password:");
                string password = Console.ReadLine();

                if (Loggin.TryLogin(firstName, password))
                {
                    Console.WriteLine($"Login successful. Hello {firstName}");
                    return true;
                }
                else
                {
                    attempts--;
                    if (attempts > 0)
                    {
                        Console.WriteLine($"You have {attempts} attempts remaining.");
                    }
                    else
                    {
                        Console.WriteLine("Login failed. Try again later.");
                    }
                }
            } while (attempts > 0);

            return false;
        }

        public bool TryLogin(string firstName, string password)
        {
            attempts = MaxAttempts; // Reset attempts when using overload
            return Loggin.TryLogin(firstName, password);
        }

        public void ResetAttempts()
        {
            attempts = MaxAttemptsForReset;
        }
    }
}
