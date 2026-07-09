using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

namespace RetailInventory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();

            try
            {
                var product = await context.Products.FirstAsync();

                product.Price += 1000;

                await context.SaveChangesAsync();

                Console.WriteLine("Product updated successfully.");
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine("Concurrency conflict detected.");
            }
        }
    }
}
