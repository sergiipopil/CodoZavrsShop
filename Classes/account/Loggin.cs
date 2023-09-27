
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Classes.account
{
    internal class Loggin
    {
        public static bool TryLogin(string firstName, string password)
        {
            try
            {
                string jsonFromFile = File.ReadAllText("UserData.json");
                List<Registration> userList = JsonConvert.DeserializeObject<List<Registration>>(jsonFromFile);

                Registration user = userList.Find(u => u.FirstName == firstName && u.Password == password);

                if (user != null)
                {

                    Console.WriteLine($"User {user.FirstName} logged in successfully.");

                    return true;
                }
                else
                {
                    Console.WriteLine("Incorrect credentials. Please try again.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public static bool TryLogin(string firstName)
        {
            return TryLogin(firstName, "");
        }
    }
}
