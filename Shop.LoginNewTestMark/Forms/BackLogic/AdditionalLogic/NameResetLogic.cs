using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Shop.LoginNewTestMark.Forms.BackLogic.AdditionalLogic
{
    class NameResetLogic : LoginLogic
    {
        private string? UserName { get; set; }
        
        public static bool IsMatch(string password)
        {
            Console.WriteLine("Please re-enter your name");
            string newPassword = Console.ReadLine();

            return !string.IsNullOrEmpty(password) && password == newPassword;
        }
        
        //Нужно будет поменять GetNewPassword на GetNewValue
        public override string GetNewPassword(string name)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Your name has been successfully changed, Hi {name}");
            return UserName;
        }
        
        public override string AdditionalProperty
        {
            get { return "please don't tell your new information"; }
        }

        public static bool ResetUserName(string name)
        {
            try
            {
                //Перенести эту часть кода в интерфейс
                if (!File.Exists(FileName))
                {
                    throw new FileNotFoundException($"File {FileName} not found.");
                }
                
                string jsonFromFile = File.ReadAllText(FileName);
                List<RegistrationLogic> userList = JsonConvert.DeserializeObject<List<RegistrationLogic>>(jsonFromFile);

                RegistrationLogic user = userList.Find(u => u.FirstName == name);
                
                if (user != null && IsMatch(name))
                {
                    user.FirstName = name;

                    File.WriteAllText(FileName, JsonConvert.SerializeObject(userList, Newtonsoft.Json.Formatting.Indented));

                    return true;
                }
                else
                {
                    Console.WriteLine($"User with first name: \"{name}\" not found.");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }
    }
};

