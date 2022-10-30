using Microsoft.EntityFrameworkCore;
using PizzaStoreEF.Models;

namespace PizzaStoreEF.Context;

public class PizzaDbContext:DbContext
{
    public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
    {
    }

    public DbSet<Pizza> Pizzas { get; set; } = null!;

}
