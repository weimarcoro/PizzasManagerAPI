using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaManager.Core.Models;

namespace PizzaManager.Core.Services
{
    public interface IPizzaService
    {
        Task<IEnumerable<Pizza>> GetAll();
        Task<Pizza> Get(int id);
        Task Add(Pizza newPizza);
        Task Update(Pizza pizza);
        Task Delete(int id);
    }
}
