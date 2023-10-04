using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Classes
{
    internal class Customer
    {
        private decimal _cash;
        public decimal Cash
        {
            get
            {
                return _cash;
            }
            set
            {
                _cash = value;
            }
        }
        public const int storeCard = 123456789;
        public readonly string FirstName;
        public string LastName { get; set; }
        public required long NumberPhone { get; set; }

        [SetsRequiredMembers]
        public Customer(string firstName, string lastName, long numberPhone, decimal cash)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.NumberPhone = numberPhone;
            this.Cash = cash;
        }
    }
}
