using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

namespace RetailInventory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();

            Console.WriteLine("Products with Price > 1000");

            var filteredProducts = await context.Products
                .Where(p => p.Price > 1000)
                .OrderByDescending(p => p.Price)
                .ToListAsync();

            foreach (var product in filteredProducts)
            {
                Console.WriteLine($"{product.Name} - ₹{product.Price}");
            }

            Console.WriteLine();

            Console.WriteLine("Product DTO");

            var productDTOs = await context.Products
                .Select(p => new
                {
                    p.Name,
                    p.Price
                })
                .ToListAsync();

            foreach (var item in productDTOs)
            {
                Console.WriteLine($"{item.Name} - ₹{item.Price}");
            }
        }
    }
}
