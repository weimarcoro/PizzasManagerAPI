using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaManager.Core.Models;

namespace PizzaManager.Core.Services
{
    public interface IIngredientService
    {
        Task<Ingredient> Get(int id);
        Task<IEnumerable<Ingredient>> GetAll();
        Task Add(Ingredient newIngredient);
        Task Update(Ingredient ingredient);
        Task Delete(int id);
        Task<Ingredient> GetMany(Func<bool> expression);
    }
}
