using System.Collections.Generic;

namespace RetailInventory.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        // One-to-One
        public ProductDetail ProductDetail { get; set; }

        // Many-to-Many
        public List<Tag> Tags { get; set; } = new();
    }
}
