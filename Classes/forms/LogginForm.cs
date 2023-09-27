using Shop.Classes.account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Classes.forms
{
    internal class LogginForm
    {
        private readonly int MaxAttempts = 3; // Добавляем readonly

        public void NewLogginForm()
        {
            int attempts = MaxAttempts;

            while (attempts > 0)
            {
                Console.WriteLine("Enter your first name:");
                string firstName = Console.ReadLine();

                Console.WriteLine("Enter your password:");
                string password = Console.ReadLine();

                if (Loggin.TryLogin(firstName, password))
                {
                    Console.WriteLine("Login successful");
                    break;
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
            }
        }
    }
}
