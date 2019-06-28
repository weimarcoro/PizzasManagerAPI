using System;
using System.Collections.Generic;
using System.Linq;
using PizzaManager.Core.Models;
using PizzaManager.Core.Repositories;

namespace PizzaManager.Data.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private PizzaManagerDbContext _context;

        public IngredientRepository(PizzaManagerDbContext context)
        {
            _context = context;
        }

        public void Add(Ingredient entity)
        {
            _context.Ingredients.Add(entity);
            _context.SaveChanges();
        }

        public Ingredient Get(int id)
        {
            return _context.Ingredients.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _context.Ingredients;
        }

        public void Remove(int id)
        {
            var ingredient = Get(id);
            _context.Ingredients.Remove(ingredient);
            _context.SaveChanges();
        }

        public void Update(Ingredient entity)
        {
            _context.Ingredients.Update(entity);
            _context.SaveChanges();
        }
    }
}
