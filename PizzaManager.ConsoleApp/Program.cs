using System;
using System.Linq;
using PizzaManager.Data;
using PizzaManager.Core.Models;

namespace PizzaManager.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var database = new PizzaManagerDbContext();

            // Agregar Dato
            /*var newPizza = new Pizza
            {
                Name = "Test Pizza"
            };

            database.Pizzas.Add(newPizza);
            database.SaveChanges();*/


            // Obtener Una Pizza
            /*var pizzas = from pizza in database.Pizzas
                         where pizza.Name.Equals("Test Pizza")
                         select pizza;

            // Modificar el Nombre de la Pizza
            var primeraPizza = pizzas.FirstOrDefault();
            primeraPizza.Name = "Test Pizza 2";

            database.Entry(primeraPizza).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            database.SaveChanges();*/

            // Eliminar Una Pizza
            var pizzas = from pizza in database.Pizzas
                         where pizza.Name.Contains("Pesto")
                         select pizza;

            var primeraCoincidencia = pizzas.FirstOrDefault();

            database.Pizzas.Remove(primeraCoincidencia);
            database.SaveChanges();

            // Obtener Todas las Pizzas
            var todasLasPizzas = from pizza in database.Pizzas
                         select pizza;

            foreach (var pizza in todasLasPizzas)
            {
                Console.WriteLine($"Pizza: {pizza.Name}");
            }


        }
    }
}
