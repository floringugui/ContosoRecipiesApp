using ContosoRecipiesApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ContosoRecipiesApi.Configuration
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("Recipes");

            builder.Property(s => s.Description)
                .IsRequired(false);

            builder.Property(s => s.Updated)
                .HasDefaultValue(DateTime.Now);

            builder.HasData(
                new Recipe
                {
                    Id = 1,
                    Title = "Breakfast1",
                    Description = "Breakfast1 Description",
                    Updated = DateTime.Now
                },
                new Recipe
                {
                    Id = 2,
                    Title = "Dinner1",
                    Description = "Dinner1 Description",
                    Updated = DateTime.Now.AddDays(-1)
                }
            );
        }
    }
}