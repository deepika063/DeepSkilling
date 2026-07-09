using RetailInventory.Data;
using RetailInventory.Models;

namespace RetailInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                if (!context.Categories.Any())
                {
                    var electronics = new Category
                    {
                        Name = "Electronics"
                    };

                    var groceries = new Category
                    {
                        Name = "Groceries"
                    };

                    context.Categories.Add(electronics);
                    context.Categories.Add(groceries);
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    var electronics = context.Categories.First(c => c.Name == "Electronics");
                    var groceries = context.Categories.First(c => c.Name == "Groceries");

                    context.Products.AddRange(
                        new Product
                        {
                            Name = "Laptop",
                            Price = 65000,
                            CategoryId = electronics.Id
                        },
                        new Product
                        {
                            Name = "Mobile",
                            Price = 25000,
                            CategoryId = electronics.Id
                        },
                        new Product
                        {
                            Name = "Rice",
                            Price = 70,
                            CategoryId = groceries.Id
                        },
                        new Product
                        {
                            Name = "Milk",
                            Price = 30,
                            CategoryId = groceries.Id
                        });

                    context.SaveChanges();
                }

                Console.WriteLine("Data inserted successfully.");
            }
        }
    }
}
