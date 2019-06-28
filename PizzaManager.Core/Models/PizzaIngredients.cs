using System;
namespace PizzaManager.Core.Models
{
    public class PizzaIngredients
    {
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
