using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaManager.Core.Models;
using PizzaManager.Core.Repositories;

namespace PizzaManager.Data.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private PizzaManagerDbContext _context;

        public PizzaRepository(PizzaManagerDbContext context)
        {
            _context = context;
        }

        public void Add(Pizza entity)
        {
            _context.Pizzas.Add(entity);
            _context.SaveChanges();
        }

        public Pizza Get(int id)
        {
            return _context.Pizzas.Where(p => p.Id == id).Include(p => p.Ingredients).ThenInclude(i => i.Ingredient).FirstOrDefault();
        }

        public IEnumerable<Pizza> GetAll()
        {
            return _context.Pizzas.Include(p => p.Ingredients).ThenInclude(i => i.Ingredient);
        }

        public void Remove(int id)
        {
            var pizza = Get(id);
            _context.Pizzas.Remove(pizza);
            _context.SaveChanges();
        }

        public void Update(Pizza entity)
        {
            _context.Pizzas.Update(entity);
            _context.SaveChanges();
        }
    }
}
