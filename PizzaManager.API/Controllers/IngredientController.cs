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
    public class IngredientController : Controller
    {
        private readonly IIngredientService _service;

        public IngredientController(IIngredientService service)
        {
            _service = service;
        }

        // GET: api/ingredient/GetAll
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var ingredients = await _service.GetAll();
            return Ok(ingredients);
        }

        // GET api/ingredient/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ingredient = await _service.Get(id);
            return Ok(ingredient);
        }

        // POST api/ingredient
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Ingredient ingredient)
        {
            if (string.IsNullOrWhiteSpace(ingredient.Name))
            {
                return BadRequest();
            }

            await _service.Add(ingredient);

            return Ok(ingredient);
        }

        // PUT api/ingredient/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Ingredient ingredient)
        {
            if (string.IsNullOrWhiteSpace(ingredient.Name) || id == 0 || id != ingredient.Id)
            {
                return BadRequest();
            }

            await _service.Update(ingredient);

            return Ok(ingredient);
        }

        // DELETE api/ingredient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);

            return Ok();
        }
    }
}
