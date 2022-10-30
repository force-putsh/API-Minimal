using PizzaStore.Model;

namespace PizzaStore.Repository
{
    public class PizzaRepos
    {
        private static List<Pizza> _pizzas = new List<Pizza>()
        {
            new Pizza()
            {
                Id = 1,
                Name = "Pepperoni",
                Description = "Pepperoni, cheese, and tomato sauce",
                Price = 10.99m
            },
            new Pizza()
            {
                Id = 2,
                Name = "Hawaiian",
                Description = "Ham, pineapple, and cheese",
                Price = 12.99m
            },
            new Pizza()
            {
                Id = 3,
                Name = "Meat Lovers",
                Description = "Pepperoni, sausage, ham, bacon, and beef",
                Price = 14.99m
            },
            new Pizza()
            {
                Id = 4,
                Name = "Veggie",
                Description = "Mushrooms, onions, green peppers, and black olives",
                Price = 11.99m
            },
            new Pizza()
            {
                Id = 5,
                Name = "Supreme",
                Description = "Pepperoni, sausage, mushrooms, onions, green peppers, and black olives",
                Price = 13.99m
            }
        };

        public static List<Pizza> GetAll()
        {
            return _pizzas;
        }

        public static Pizza? GetById(int id)
        {
            return _pizzas.SingleOrDefault(p => p.Id == id);
        }

        public static Pizza Add(Pizza pizza)
        {
            _pizzas.Add(pizza);
            return pizza;
        }

        public static Pizza Update(Pizza update)
        {
            _pizzas = _pizzas.Select(p =>
            {
                if (p.Id == update.Id)
                {
                    p.Price = update.Price;
                    p.Name = update.Name;
                    p.Description = update.Description;
                }
                return p;
            }).ToList();
            return update;
        }

        public static void Delete(int id)
        {
            _pizzas = _pizzas.Where(p => p.Id != id).ToList();
        }
    }
}
