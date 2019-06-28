using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PizzaManager.Core.Models;

namespace PizzaManager.Data
{
    public class PizzaManagerDbContext : DbContext
    {
        public PizzaManagerDbContext()
        {
        }

        public PizzaManagerDbContext(DbContextOptions<PizzaManagerDbContext> options) : base(options)
        {

        }

        public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<PizzaManagerDbContext>
        {
            public static IConfigurationRoot Configuration;

            public static string GetConnectionString()
            {
                var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");

                Configuration = builder.Build();
                return Configuration[$"ConnectionStrings:Pizza_Connection"];

            }

            public PizzaManagerDbContext CreateDbContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<PizzaManagerDbContext>();
                builder.UseMySql(GetConnectionString());
                return new PizzaManagerDbContext(builder.Options);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaIngredients>()
                .HasKey(bc => new { bc.PizzaId, bc.IngredientId });
            modelBuilder.Entity<PizzaIngredients>()
                .HasOne(bc => bc.Ingredient)
                .WithMany(b => b.Pizzas)
                .HasForeignKey(bc => bc.IngredientId);
            modelBuilder.Entity<PizzaIngredients>()
                .HasOne(bc => bc.Pizza)
                .WithMany(c => c.Ingredients)
                .HasForeignKey(bc => bc.PizzaId);
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<PizzaIngredients> PizzasIngredients { get; set; }
    }
}
