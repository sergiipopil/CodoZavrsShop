﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Classes
{
    public class ShopManager
    {
        public void Open(Shop shop)
        {
            shop.IsOpened = true;
        }

        public void Open(Shop shop, string openTime)
        {
            shop.IsOpened = true;
            Console.WriteLine($"Store {shop.Name} is opened at the address {Shop.Location}, " +
                $"StoreId:{shop.ShopID}, Shop opened at: {openTime}");
        }

        public void Close(Shop shop)
        {
            shop.IsOpened = false;
            Console.WriteLine($"Store {shop.Name} is closed at the address {Shop.Location}, StoreId:{shop.ShopID}");
        }
    }
}
