namespace PizzaHut.Services;

using PizzaHut.Models;

public static class PizzaService
{
    static List<Pizza> Pizzas { get; }
    static int nextId = 3;
    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Classic Italian", GlutenFree = false },
            new Pizza { Id = 2, Name = "Veggie", GlutenFree = true }
        };
    }
    public static List<Pizza> GetAllPizzas()
    {
        return Pizzas;
    }

    public static Pizza? GetPizzaById(int id)
    {
        return Pizzas.FirstOrDefault(p => p.Id == id);
    }

    public static void AddPizza(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void UpdatePizza(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1) return;
        Pizzas[index] = pizza;
    }

    public static void DeletePizza(int id)
    {
        var index = Pizzas.FindIndex(p => p.Id == id);
        if (index == -1) return;
        Pizzas.RemoveAt(index);
    }
}