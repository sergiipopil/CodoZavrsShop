using PhoneNumbers;
using Shop.Classes.account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shop.Classes.forms
{

    internal class RegistrationForm
    {
        private const int MaxAttempts = 3;

        //Validations
        static bool IsValidPassword(string password)
        {
            if (password.Length < 8)
                return false;

            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasSymbol = false;
            bool hasNumber = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUpperCase = true;

                if (char.IsLower(c))
                    hasLowerCase = true;

                if (char.IsLetterOrDigit(c))
                    hasSymbol = true;
                if (char.IsNumber(c))
                    hasNumber = true;
            }

            return hasUpperCase && hasLowerCase && hasSymbol && hasNumber;
        }

        static bool IsValidEmail(string email)
        {
            if (email == null)
                return false;

            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }

         static bool IsValidName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            if (!char.IsUpper(name[0]))
                return false;

            for (int i = 1; i < name.Length; i++)
            {
                if (!char.IsLetter(name[i]))
                    return false;
            }

            return true;
        }



        //Registration Form
        public void NewRegistrationForm() 
        {
            int attempts = MaxAttempts;


            string userFirstName = "";
            do
            {
                Console.WriteLine("Please enter your First Name:");
                userFirstName = Console.ReadLine();
            } while (!IsValidName(userFirstName));


            string userLastName = "";
            do
            {
                Console.WriteLine("Please enter your Last Name:");
                userLastName = Console.ReadLine();
            } while (!IsValidName(userLastName));

            
            string userEmail = "";

            do
            {
                Console.WriteLine("Please enter your Email:");
                userEmail = Console.ReadLine();
            } while (!IsValidEmail(userEmail));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Email is valid.");


            string userPassword = "";
            bool isPasswordValid = false;

            while (!isPasswordValid)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please enter your Password:");
                userPassword = Console.ReadLine();


                if (IsValidPassword(userPassword))
                {
                    isPasswordValid = true;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Password is valid.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid password. Please try again.");
                }
            }


            bool isPhoneNumberValid = false;

            string userCountryCode = "";
            string userPhoneNumber = "";

            while (attempts > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please enter your Country Code | For example '+380':");
                userCountryCode = Console.ReadLine();

                Console.WriteLine("Please enter your Phone Number | For example '50 000 0000':");
                string userPhoneNumberNew = Console.ReadLine();

                PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();

                try
                {
                    PhoneNumber number = phoneNumberUtil.Parse(userCountryCode + userPhoneNumberNew, null);
                    int countryCode = number.CountryCode;

                    userPhoneNumber = userPhoneNumberNew;
                    Console.WriteLine("Country code: " + countryCode);
                    isPhoneNumberValid = true;
                    break; // Если номер валиден, выходим из цикла.
                }
                catch (NumberParseException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error in parsing number: " + e.Message);
                    attempts--;
                    Console.WriteLine("You have " + attempts + " attempt(s) left.");
                }


            }




            if (isPhoneNumberValid)
            {
                Registration user = new Registration(
                    firstName: userFirstName,
                    lastName: userLastName,
                    email: userEmail, 
                    password: userPassword,
                    phoneNumber: userCountryCode + userPhoneNumber
                    );
                user.SaveUserData();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("All attempts have been exhausted. Registration failed.");
            }

        }
    }
}
