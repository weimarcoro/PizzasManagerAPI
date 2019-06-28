using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaManager.Core.Models;
using PizzaManager.Core.Repositories;
using PizzaManager.Core.Services;

namespace PizzaManager.API.Services
{
    public class PizzaService : IPizzaService
    {
        private IPizzaRepository _repository;

        public PizzaService(IPizzaRepository repository)
        {
            _repository = repository;
        }

        public Task Add(Pizza newPizza)
        {
            return Task.Run(() =>
            {
                _repository.Add(newPizza);
            });
        }

        public Task Delete(int id)
        {
            return Task.Run(() =>
            {
                _repository.Remove(id);
            });
        }

        public Task<Pizza> Get(int id)
        {
            return Task.Run(() =>
            {
                return _repository.Get(id);
            });
        }

        public Task<IEnumerable<Pizza>> GetAll()
        {
            return Task.Run(() =>
            {
                return _repository.GetAll();
            });
        }

        public Task Update(Pizza pizza)
        {
            return Task.Run(() =>
            {
                _repository.Update(pizza);
            });
        }
    }
}
