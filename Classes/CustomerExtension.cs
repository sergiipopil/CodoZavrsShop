using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Classes
{
    internal static class CustomerExtension
    {
        public static void GetInformationCustomer(this Customer customer, CustomerRecord customerRecord)
        {
            Console.WriteLine($"\nCustomer information:\n\n" +
               $"Name - {customer.FirstName}\n" +
               $"Surname - {customer.LastName}\n" +
               $"Birthday - {customerRecord.BirthDay}\n" +
               $"Phone number - {customer.NumberPhone}\n" +
               $"Customer cach - {customer.Cash}\n" +
               $"Customer discount % - {customerRecord.Discount}\n"
               );
        }
    }
}
