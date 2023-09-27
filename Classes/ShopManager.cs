using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Classes
{
    public class ShopManager
    {
        public Shop shop = new Shop();

        public void Open()
        {
            shop.IsOpened = true;
        }

        public void Open(string openTime)
        {
            shop.IsOpened = true;
            Console.WriteLine($"Store {shop.Name} is opened at the address {Shop.Location}, " +
                $"StoreId:{shop.ShopID}, Shop opened at: {openTime}");
        }

        public void Close()
        {
            shop.IsOpened = false;
            Console.WriteLine($"Store {shop.Name} is closed at the address {Shop.Location}, StoreId:{shop.ShopID}");
        }
    }
}
