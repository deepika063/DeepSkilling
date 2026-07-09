using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Models;

namespace RetailInventory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();

            var productDTOs = await context.Products
                .Select(p => new ProductDTO
                {
                    Name = p.Name,
                    CategoryName = p.Category.Name
                })
                .ToListAsync();

            foreach (var item in productDTOs)
            {
                Console.WriteLine($"{item.Name} - {item.CategoryName}");
            }
        }
    }
}
