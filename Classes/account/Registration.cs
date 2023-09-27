using Newtonsoft.Json;
using System.IO;
using System.Text.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shop.Classes.account
{
    internal class Registration
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        private static List<Registration> users = new List<Registration>();

        //public List<ProgramingEnums> Learning { get; set; }


        //Дополнительный функционал
        public string Notification { get; set; }

        public Registration(string firstName, string lastName, string email, string password, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            //Learning = new List<ProgramingEnums>();
        }

        // Остальной код остается без изменений
        public void SaveUserData()
        {
            try
            {
                var user = new
                {
                    FirstName,
                    LastName,
                    Email,
                    Password,
                    PhoneNumber
                };

                string json = JsonConvert.SerializeObject(user);

                if (!File.Exists("UserData.json"))
                {
                    File.WriteAllText("UserData.json", "[" + json + "]");
                    Console.WriteLine("Data saved successfully");
                }
                else
                {
                    string jsonFromFile = File.ReadAllText("UserData.json");
                    List<Registration> userList = JsonConvert.DeserializeObject<List<Registration>>(jsonFromFile);

                    // Проверка наличия пользователя с таким же email
                    if (userList.Any(u => u.Email == Email))
                    {
                        Console.WriteLine("User with this email already exists.");
                    }
                    else
                    {
                        userList.Add(new Registration(FirstName, LastName, Email, Password, PhoneNumber));
                        string updatedJson = JsonConvert.SerializeObject(userList, Formatting.Indented);
                        File.WriteAllText("UserData.json", updatedJson);
                        Console.WriteLine("Data appended successfully");
                        //PrintUsers();
                    }

                    foreach (var users in userList)
                    {
                        Console.WriteLine("Data from user.json:");
                        Console.WriteLine($"Name: {users.FirstName}");
                        Console.WriteLine($"Ilchenko: {users.Email}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred, please try later: {ex.Message}");
            }
        }


        public string userData(string value)
        {
            Console.WriteLine($"Please enter your {value}");
            return value;
        }

        public static List<Registration> GetUsers()
        {
            return users;
        }

        public void PrintUsers()
        {
            foreach (var user in users)
            {
                Console.WriteLine($"Name: {user.FirstName}, Email: {user.Email}");
            }
        }

        
    }
}
