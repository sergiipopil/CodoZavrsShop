using Newtonsoft.Json;
using Shop.LoginNewTestMark.Forms.BackLogic.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.LoginNewTestMark.Forms.BackLogic.AdditionalLogic
{
    class PasswordResetLogic : LoginLogic
    {
        
        public string Password { get; set; }

        public static bool IsMatch(string password)
        {
            Console.WriteLine("Please re-enter your password");
            string newPassword = Console.ReadLine();

            return !string.IsNullOrEmpty(password) && password == newPassword;
        }

        public override string GetNewPassword(string password)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Your password {password} is match with {password}");
            return Password;
        }

        public override string AdditionalProperty
        {
            get { return "please don't tell anyone your password"; }
        }

        public static bool ResetPassword(string firstName, string newPassword)
        {
            try
            {
                if (!File.Exists(FileName))
                {
                    throw new FileNotFoundException($"File {FileName} not found.");
                }

                string jsonFromFile = File.ReadAllText(FileName);
                List<RegistrationLogic> userList = JsonConvert.DeserializeObject<List<RegistrationLogic>>(jsonFromFile);

                RegistrationLogic user = userList.Find(u => u.FirstName == firstName);

                if (user != null && IsMatch(newPassword))
                {
                    user.Password = newPassword;

                    File.WriteAllText(FileName, JsonConvert.SerializeObject(userList, Newtonsoft.Json.Formatting.Indented));

                    return true;
                }
                else
                {
                    Console.WriteLine($"User with first name: \"{firstName}\" not found.");
                    return false;
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex}");
                return false;
            }
        }
    }
}
