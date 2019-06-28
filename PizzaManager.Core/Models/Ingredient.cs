using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaManager.Core.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PizzaIngredients> Pizzas { get; set; }
    }
}
