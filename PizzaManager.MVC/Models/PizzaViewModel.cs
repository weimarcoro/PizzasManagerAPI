using System;
using System.Collections.Generic;

namespace PizzaManager.MVC.Models
{
    public class PizzaViewModel
    {
        public PizzaViewModel()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public List<IngredientViewModel> Ingredients { get; set; }
    }
}
