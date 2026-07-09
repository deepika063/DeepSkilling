using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

namespace RetailInventory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();

            Console.WriteLine("----- All Products -----");

            var products = await context.Products.ToListAsync();

            foreach (var p in products)
            {
                Console.WriteLine($"{p.Id} {p.Name} ₹{p.Price}");
            }

            Console.WriteLine();

            Console.WriteLine("----- Find By Id -----");

            var product = await context.Products.FindAsync(1);

            if (product != null)
                Console.WriteLine($"{product.Name}");

            Console.WriteLine();

            Console.WriteLine("----- Expensive Product -----");

            var expensive = await context.Products
                .FirstOrDefaultAsync(p => p.Price > 50000);

            if (expensive != null)
                Console.WriteLine($"{expensive.Name} ₹{expensive.Price}");
        }
    }
}
