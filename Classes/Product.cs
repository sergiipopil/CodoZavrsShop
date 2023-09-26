using System.Diagnostics.CodeAnalysis;

namespace Shop.Classes
{
    public class Product
    {
        public const string Currency = "EUR";
        public readonly DateTime Expiration = DateTime.Now.AddMonths(1);
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required int Count { get; set; }
        public required decimal Price { get; set; }
        public int Weight { get; set; }        
        [SetsRequiredMembers]
        public Product()
        {
        }
    }
}
