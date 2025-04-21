using Microsoft.EntityFrameworkCore;
using PizzaHut.Models;

namespace PizzaHut.Data
{
	public class PizzaDbContext : DbContext
	{
		public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
		{
		}
		public DbSet<Pizza> Pizzas { get; set; } = null!;
	}
}