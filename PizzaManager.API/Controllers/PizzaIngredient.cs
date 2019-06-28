using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaManager.Core.Models;
using PizzaManager.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaManager.API.Controllers
{
    [Route("api/[controller]")]
    public class PizzaIngredient : Controller
    {
        private readonly IPizzaService _pizzaService;

        public PizzaIngredient(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        // PUT api/pizzaingredient/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody] Ingredient ingredient)
        {
            if (id == 0 || ingredient == null || ingredient.Id == 0)
            {
                return BadRequest();
            }

            var pizza = await _pizzaService.Get(id);
            pizza.Ingredients.Add(new PizzaIngredients
            {
                IngredientId = ingredient.Id,
                PizzaId = id
            });

            await _pizzaService.Update(pizza);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromBody] Ingredient ingredient)
        {
            if (id == 0 || ingredient == null || ingredient.Id == 0)
            {
                return BadRequest();
            }

            var pizza = await _pizzaService.Get(id);
            var existingIngredient = pizza.Ingredients.FirstOrDefault(i => i.IngredientId == ingredient.Id);
            pizza.Ingredients.Remove(existingIngredient);

            await _pizzaService.Update(pizza);

            return Ok();
        }
    }
}
