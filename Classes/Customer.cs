using System;
using System.Collections.Generic;
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
        public readonly string Name;
        public required int NumberPhone { get; set; }
        public Customer(string name)
        {
            Name = name;
        }
    }
}
