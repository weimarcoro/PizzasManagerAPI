using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaManager.Core.Extensions;
using PizzaManager.Core.Models;
using PizzaManager.Core.Repositories;
using PizzaManager.Core.Services;

namespace PizzaManager.API.Services
{
    public class IngredientService : IIngredientService
    {
        private IIngredientRepository _repository;

        public IngredientService(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public Task Add(Ingredient newIngredient)
        {
            return Task.Run(() =>
            {
                _repository.Add(newIngredient);
            });
        }

        public Task Delete(int id)
        {
            return Task.Run(() =>
            {
                _repository.Remove(id);
            });
        }

        public Task<Ingredient> Get(int id)
        {
            return Task.Run(() =>
            {
                return _repository.Get(id);
            });
        }

        public Task<IEnumerable<Ingredient>> GetAll()
        {
            return Task.Run(() =>
            {
                return _repository.GetAll();
            });
        }

        public Task<Ingredient> GetMany(Func<bool> expression)
        {
            throw new PizzaManagerException();
        }

        public Task Update(Ingredient ingredient)
        {
            return Task.Run(() =>
            {
                _repository.Update(ingredient);
            });
        }
    }
}
