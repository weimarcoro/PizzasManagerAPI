using System;
using System.Collections.Generic;

namespace PizzaManager.Core.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PizzaIngredients> Ingredients { get; set; }
    }
}
