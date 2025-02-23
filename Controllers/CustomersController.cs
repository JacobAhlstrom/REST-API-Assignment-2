using DagnysBakeryAPI.Data;
using DagnysBakeryAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DagnysBakeryAPI.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly BakeryContext _context;

    public CustomersController(BakeryContext context)
    {
        _context = context;
    }

    // Lägg till kund
    [HttpPost]
    public async Task<IActionResult> AddCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
    }

    // Hämta lista av kunder
    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        return Ok(await _context.Customers.ToListAsync());
    }

    // Hämta en specifik kund med beställningshistorik
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(int id)
    {
        var customer = await _context.Customers
            .Include(c => c.Orders)
            .ThenInclude(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (customer == null) return NotFound();
        return Ok(customer);
    }
}

