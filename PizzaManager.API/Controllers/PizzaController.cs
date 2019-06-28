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
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;
        private readonly IIngredientService _ingredientService;

        public PizzaController(IPizzaService pizzaService, IIngredientService ingredientService)
        {
            _pizzaService = pizzaService;
            _ingredientService = ingredientService;
        }

        // GET: api/pizza/GetAll
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var pizzas = await _pizzaService.GetAll();
            return Ok(pizzas.Select(p => new
            {
                p.Id,
                p.Name,
                Ingredients = p.Ingredients.Select(i => new
                {
                    Id = i.IngredientId,
                    i.Ingredient.Name
                })
            }));
        }

        // GET api/pizza/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var pizza = await _pizzaService.Get(id);
            return Ok(new
            {
                pizza.Id,
                pizza.Name,
                Ingredients = pizza.Ingredients.Select(i => new
                {
                    Id = i.IngredientId,
                    i.Ingredient.Name
                })
            });
        }

        // POST api/pizza
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Pizza pizza)
        {
            if (string.IsNullOrWhiteSpace(pizza.Name))
            {
                return BadRequest();
            }

            await _pizzaService.Add(pizza);

            return Ok(pizza);
        }

        // PUT api/pizza/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Pizza pizza)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(pizza.Name) || pizza.Id != id || pizza == null)
            {
                return BadRequest();
            }

            await _pizzaService.Update(pizza);

            return Ok(pizza);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _pizzaService.Delete(id);
            return Ok();
        }

    }
}
