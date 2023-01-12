using ContosoRecipiesApi.Configuration;
using ContosoRecipiesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoRecipiesApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; } = default!;

        public DbSet<Direction> Directions { get; set; } = default!;

        public DbSet<Ingredient> Ingredients { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeConfiguration());
            modelBuilder.ApplyConfiguration(new DirectionConfiguration());
            modelBuilder.ApplyConfiguration(new IngredientConfiguration());
        }
    }
}