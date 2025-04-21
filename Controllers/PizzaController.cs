using Microsoft.AspNetCore.Mvc;
using PizzaHut.Models;
using PizzaHut.Services;

namespace PizzaHut.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PizzaController : ControllerBase
{

    private readonly ILogger<PizzaController> _logger;

    public PizzaController(ILogger<PizzaController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAllPizzas()
    {
        _logger.LogInformation("Fetching all pizzas");
        return PizzaService.GetAllPizzas();
    }

    [HttpGet("{id}")]
    public ActionResult<Pizza> GetPizzaById(int id)
    {
        var pizza = PizzaService.GetPizzaById(id);
        if (pizza == null)
        {
            return NotFound();
        }
        return pizza;
    }

    [HttpPost]
    public ActionResult<Pizza> AddPizza(Pizza pizza)
    {
        PizzaService.AddPizza(pizza);
        return CreatedAtAction(nameof(GetPizzaById), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePizza(int id, Pizza pizza)
    {
        if (id != pizza.Id)
        {
            return BadRequest();
        }
        var existingPizza = PizzaService.GetPizzaById(id);
        if (existingPizza == null)
        {
            return NotFound();
        }
        PizzaService.UpdatePizza(pizza);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePizza(int id)
    {
        var existingPizza = PizzaService.GetPizzaById(id);
        if (existingPizza == null)
        {
            return NotFound();
        }
        PizzaService.DeletePizza(id);
        return NoContent();
    }
}