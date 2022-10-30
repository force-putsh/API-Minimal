using Microsoft.EntityFrameworkCore;
using PizzaStoreEF.Context;
using PizzaStoreEF.Models;

namespace PizzaStoreEF.DTA;

public class PizzaRepository
{
    private readonly PizzaDbContext _context;

    public PizzaRepository(PizzaDbContext context)
    {
        _context = context;
    }
    
    public PizzaRepository() { }

    public async Task<List<Pizza>> GetPizzasAsync()
    {
        return await _context.Pizzas.ToListAsync();
    }

    public async Task<Pizza> GetPizzaAsync(int id)
    {
        return await _context.Pizzas.FindAsync(id);
    }

    public async Task<Pizza> AddPizzaAsync(Pizza pizza)
    {
        _context.Pizzas.Add(pizza);
        await _context.SaveChangesAsync();
        return pizza;
    }

    public async Task<Pizza> UpdatePizzaAsync(Pizza pizza)
    {
        _context.Entry(pizza).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return pizza;
    }

    public async Task<Pizza> DeletePizzaAsync(int id)
    {
        var pizza = await _context.Pizzas.FindAsync(id);
        if (pizza == null)
        {
            return pizza;
        }

        _context.Pizzas.Remove(pizza);
        await _context.SaveChangesAsync();

        return pizza;
    }

    public bool PizzaExists(int id)
    {
        return _context.Pizzas.Any(e => e.Id == id);
    }
}
