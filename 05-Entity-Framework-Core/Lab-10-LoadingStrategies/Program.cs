using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

namespace RetailInventory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();

            Console.WriteLine("=== Eager Loading ===");

            var products = await context.Products
                .Include(p => p.Category)
                .ToListAsync();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} - {product.Category.Name}");
            }

            Console.WriteLine();

            Console.WriteLine("=== Explicit Loading ===");

            var firstProduct = await context.Products.FirstAsync();

            await context.Entry(firstProduct)
                .Reference(p => p.Category)
                .LoadAsync();

            Console.WriteLine($"{firstProduct.Name} - {firstProduct.Category.Name}");

            Console.WriteLine();

            Console.WriteLine("=== Lazy Loading ===");

            var lazyProduct = await context.Products.FirstAsync();

            Console.WriteLine($"{lazyProduct.Name} - {lazyProduct.Category.Name}");
        }
    }
}
