using Shop.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Classes
{
    public class ShopMenu
    {
        public Product product = new Product();
        public Shop shop = new Shop();
        public ShopManager shopManager = new ShopManager();
        public ShopMenu()
        {
            MainMenu();
        }
        private void InitProductList()
        {
            product.ProductList = new List<Product>()
            {
                new Product() { Id = 1, Title = "Сhocolate", Count = 25, Price = 65.3m, Weight=300},
                new Product() { Id = 2, Title = "Milk", Count = 30, Price = 52.5m, Weight=1000 },
                new Product() { Id = 3, Title = "Coffee", Count = 45, Price = 247.8m, Weight=900 },
                new Product() { Id = 4, Title = "Tea", Count = 20, Price = 195, Weight=500 },
                new Product() { Id = 5, Title = "Sugar", Count = 120, Price = 35, Weight=1000 }
            };
        }
        private void MainMenu()
        {
            InitProductList();
            Console.Clear();
            Console.WriteLine($"You are welcome to {shop.Name}\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Main menu:\n\n" +
                "Press 0 - EXIT\n" +
                "Press 1 - Seller Mode\n" +
                "Press 2 - Buyer Mode\n");
            Console.ResetColor();
            Console.Write("Select menu item:");
            bool isCorrectMode = Enum.TryParse(Console.ReadLine(), out AppMode modeType);

            if (!isCorrectMode && !Enum.IsDefined(typeof(AppMode), modeType))
            {
                MainMenu();
            }
            else
            {
                switch (modeType)
                {
                    case AppMode.Exit:
                        Console.WriteLine("Thanks for visit us!");
                        Environment.Exit(0);
                        break;
                    case AppMode.Seller:
                        Console.Clear();
                        SellerMenu();
                        break;
                    case AppMode.Buyer:
                        Console.Clear();
                        BuyerMenu();
                        break;
                }
            }
        }
        private void SellerMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Seller menu:\n\n" +
                "Press 0 - Return to Main Menu\n" +
                "Press 1 - Sold item\n" +
                "Press 2 - Add item\n" +
                "Press 3 - Delete item\n" +
                "Press 4 - Get all items\n" +
                "Press 5 - Get item details by Id\n" +
                "Press 6 - Get item details by Title\n" +
                "Press 7 - Delete expiration products\n"+
                "Press 8 - Open shop\n" +
                "Press 9 - Close shop\n");
            Console.ResetColor();
            Console.Write("Select menu item:");
            bool isCorrectMode = Enum.TryParse(Console.ReadLine(), out SellerMode sellerModeType);

            if (!isCorrectMode && !Enum.IsDefined(typeof(SellerMode), sellerModeType))
            {
                Console.Clear();
                SellerMenu();
            }
            else
            {
                switch (sellerModeType)
                {
                    case SellerMode.MainMenu:
                        MainMenu();
                        break;
                    case SellerMode.AddItem:
                        //todo
                        Console.WriteLine("Add item");
                        break;
                    case SellerMode.DeleteItem:
                        //todo
                        Console.WriteLine("Delete item");
                        break;
                    case SellerMode.SoldItem:
                        //todo
                        Console.WriteLine("Sold item");
                        break;
                    case SellerMode.GetAllItems:
                        product.ShowProductsList();
                        break;
                    case SellerMode.ItemDetailsById:
                        Console.Write("Please enter Id of product which you want get details:");
                        bool isCorrectId = int.TryParse(Console.ReadLine(), out int productId);
                        if (isCorrectId)
                        {
                            product.GetProductDetail(productId);
                        }
                        break;
                    case SellerMode.ItemDetailsByTitle:
                        Console.Write("Please enter Title of product which you want get details:");
                        string title = Console.ReadLine();
                        product.GetProductDetail(title);
                        break;
                    case SellerMode.OpenShop:
                        Console.WriteLine("Please enter the opening time of the shop (for example 8:00):");
                        string openTime = Console.ReadLine();
                        shopManager.Open(openTime);
                        break;
                    case SellerMode.CloseShop:
                        shopManager.Close();
                        break;
                }
                SellerMenu();
            }
        }
        private void BuyerMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Buyer menu:\n\n" +
                "Press 0 - Return to Main Menu\n" +
                "Press 1 - Buy item\n" +
                "Press 2 - Return item\n" +
                "Press 3 - Get all items\n" +
                "Press 4 - Get item detais by Id\n" +
                "Press 5 - Get item detais by Title\n");
            Console.ResetColor();
            Console.Write("Select menu item:");
            bool isCorrectMode = Enum.TryParse(Console.ReadLine(), out BuyerMode buyerModeType);

            if (!isCorrectMode && !Enum.IsDefined(typeof(BuyerMode), buyerModeType))
            {
                Console.Clear();
                BuyerMenu();
            }
            else
            {
                switch (buyerModeType)
                {
                    case BuyerMode.MainMenu:
                        MainMenu();
                        break;
                    case BuyerMode.BuyItem:
                        //todo
                        break;
                    case BuyerMode.ReturnItem:
                        //todo
                        Console.WriteLine("Return item");
                        break;
                    case BuyerMode.ItemDetailsById:
                        Console.Write("Please enter Id of product which you want get details:");
                        bool isCorrectId = int.TryParse(Console.ReadLine(), out int productId);
                        if (isCorrectId)
                        {
                            product.GetProductDetail(productId);
                        }
                        break;
                    case BuyerMode.ItemDetailsByTitle:
                        Console.Write("Please enter Title of product which you want get details:");
                        string title = Console.ReadLine();
                        product.GetProductDetail(title);
                        break;
                    case BuyerMode.GetAllItems:
                        product.ShowProductsList();
                        break;
                }
                BuyerMenu();
            }
        }
    }
}
