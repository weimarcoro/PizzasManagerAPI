using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaManager.Core.Services;
using PizzaManager.MVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaManager.MVC.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        // GET: /<controller>/
        // public async IActionResult Index()
        // {
        //     var listOfPizzas = await _pizzaService.GetAll();
        //     var listOfPizzasDTO = new List<PizzaViewModel>();
        //     foreach (var pizza in listOfPizzas)
        //     {
        //         listOfPizzasDTO.Add(new PizzaViewModel
        //         {
        //             Id = pizza.Id,
        //             Name = pizza.Name,
        //             Ingredients = pizza.Ingredients.Select(i => new IngredientViewModel
        //             {
        //                 Id = i.IngredientId,
        //                 Name = i.Ingredient.Name
        //             }).ToList()
        //         });
        //     }
        //     return View(listOfPizzasDTO);
        // }
    }
}
