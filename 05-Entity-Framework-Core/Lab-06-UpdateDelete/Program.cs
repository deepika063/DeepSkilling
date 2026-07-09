using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

namespace RetailInventory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();

            // Update Product Price
            var product = await context.Products
                .FirstOrDefaultAsync(p => p.Name == "Laptop");

            if (product != null)
            {
                product.Price = 70000;
                await context.SaveChangesAsync();

                Console.WriteLine("Laptop price updated successfully.");
            }

            // Delete Product
            var deleteProduct = await context.Products
                .FirstOrDefaultAsync(p => p.Name == "Rice Bag");

            if (deleteProduct != null)
            {
                context.Products.Remove(deleteProduct);
                await context.SaveChangesAsync();

                Console.WriteLine("Rice Bag deleted successfully.");
            }
        }
    }
}
