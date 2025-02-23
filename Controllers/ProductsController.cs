using DagnysBakeryAPI.Data;
using DagnysBakeryAPI.Entities;
using DagnysBakeryAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DagnysBakeryAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly BakeryContext _context;

        public ProductsController(BakeryContext context)
        {
            _context = context;
        }

        // Lägg till produkt
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // Lista produkter
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        // Hämta specifik produkt
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            if (id != updatedProduct.Id)
            {
                return BadRequest("Produkt-ID matchar inte.");
            }

            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound("Produkten finns inte.");
            }

            existingProduct.Price = updatedProduct.Price; // Uppdatera priset
            await _context.SaveChangesAsync();

            return NoContent(); // Returnera 204 No Content vid lyckad uppdatering
        }

    }
}