using ContosoRecipiesApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoRecipiesApi.Configuration
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("Ingredients");

            builder.Property(s => s.Description)
                .IsRequired(false);

            builder.HasData(
                new Ingredient
                {
                    Id = 1,
                    Name = "Ingredient1",
                    Description = "Ingredient1 Description",
                    RecipeId = 1
                },
                new Ingredient
                {
                    Id = 2,
                    Name = "Ingredient2",
                    Description = "Ingredient2 Description",
                    RecipeId = 1
                },
                new Ingredient
                {
                    Id = 3,
                    Name = "Ingredient3",
                    Description = "Ingredient3 Description",
                    RecipeId = 2
                },
                new Ingredient
                {
                    Id = 4,
                    Name = "Ingredient4",
                    Description = "Ingredient4 Description",
                    RecipeId = 2
                });
        }
    }
}