using EFCore.BulkExtensions;
using RetailInventory.Data;

namespace RetailInventory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();

            var products = context.Products.ToList();

            foreach (var product in products)
            {
                product.StockQuantity += 10;
            }

            await context.BulkUpdateAsync(products);

            Console.WriteLine("Bulk update completed successfully.");
        }
    }
}
