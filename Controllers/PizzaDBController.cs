using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaHut.Data;
using PizzaHut.Models;

namespace PizzaHut.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PizzaDBController : ControllerBase
{
    private readonly PizzaDbContext _context;
    public PizzaDBController(PizzaDbContext context)
    {
        _context = context;
    }

    // GET: api/PizzaDB
    [HttpGet]
    public async Task<ActionResult<Pizza>> GetPizzas()
    {
        return await _context.Pizzas.ToListAsync();
    }

    // GET: api/PizzaDB/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Pizza>> GetPizza(int id)
    {
        var pizza = await _context.Pizzas.FindAsync(id);
        if (pizza == null)
        {
            return NotFound();
        }
        return pizza;
    }

    // POST: api/PizzaDB
    [HttpPost]
    public async Task<ActionResult<Pizza>> PostPizza(Pizza pizza)
    {
        _context.Pizzas.Add(pizza);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetPizza", new { id = pizza.Id }, pizza);
    }
}