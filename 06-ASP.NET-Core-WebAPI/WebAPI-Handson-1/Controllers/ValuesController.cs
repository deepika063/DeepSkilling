using Microsoft.AspNetCore.Mvc;
using WebAPIHandson.Models;

namespace WebAPIHandson.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 65000 },
            new Product { Id = 2, Name = "Mobile", Price = 25000 }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            products.Add(product);

            return Ok("Product Added Successfully");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Product product)
        {
            var existing = products.FirstOrDefault(p => p.Id == id);

            if (existing == null)
                return NotFound();

            existing.Name = product.Name;
            existing.Price = product.Price;

            return Ok("Product Updated Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            products.Remove(product);

            return Ok("Product Deleted Successfully");
        }
    }
}
