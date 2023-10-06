using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Classes
{
    public class ProductManagerBase<T> where T : ProductBase
    {
        public void ShowMainProductInfo(ProductBase product)
        {
            Console.WriteLine($"ID:{product.Id}\tTitle:{product.Title}\tCount:{product.Count}\tPrice:{product.Price}\tProduction:{product.Production}");
        }
        public void ChangeProductPrice(ProductBase product, decimal price)
        {
            product.Price = price;
        }
    }
}
