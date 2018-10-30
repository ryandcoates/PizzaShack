using PizzaShack.Data;
using PizzaShack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaShack.Business
{
    public class PizzaService
    {
        private readonly PizzaContext _context;

        public PizzaService(PizzaContext context)
        {
            _context = context;
        }

        public void CreatePizza(Pizza data)
        {
            _context.Pizzas.Add(data);
            _context.SaveChanges();
        }

        public Pizza GetPizzaById(int id)
        {
            return _context.Pizzas.Find(id);
        }

        public List<Pizza> GetPizzas()
        {
            return _context.Pizzas.ToList();
        }

        public Pizza UpdatePizza(Pizza data)
        {
            _context.Pizzas.Update(data);
            _context.SaveChanges();
            return data;
        }
    }
}
