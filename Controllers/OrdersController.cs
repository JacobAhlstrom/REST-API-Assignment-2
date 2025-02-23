using DagnysBakeryAPI.Data;
using DagnysBakeryAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DagnysBakeryAPI.Controllers;

[Route("api/orders")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly BakeryContext _context;

    public OrdersController(BakeryContext context)
    {
        _context = context;
    }

    // Lägg till beställning
    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(Order order)
    {
        if (order == null)
        {
            return BadRequest("Order information is invalid.");
        }

        // Lägger till ordern i databasen
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
    }


    // Lista beställningar
    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .ToListAsync();

        return Ok(await _context.Orders.Include(o => o.OrderItems).ToListAsync());
    }

    // Hämta beställning via ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(int id)
    {
        var order = await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null) return NotFound();
        return Ok(order);
    }
}

