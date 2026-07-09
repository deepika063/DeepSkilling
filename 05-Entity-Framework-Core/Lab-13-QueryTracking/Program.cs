using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Models;

namespace RetailInventory
{
    class Program
    {
        static readonly Func<AppDbContext, decimal, IAsyncEnumerable<Product>>
            ExpensiveProductsQuery =
            EF.CompileAsyncQuery(
                (AppDbContext context, decimal price) =>
                    context.Products.Where(p => p.Price > price));

        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();

            Console.WriteLine("=== AsNoTracking ===");

            var products = await context.Products
                .AsNoTracking()
                .ToListAsync();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} - ₹{product.Price}");
            }

            Console.WriteLine();

            Console.WriteLine("=== Compiled Query ===");

            await foreach (var product in ExpensiveProductsQuery(context, 10000))
            {
                Console.WriteLine($"{product.Name} - ₹{product.Price}");
            }
        }
    }
}
