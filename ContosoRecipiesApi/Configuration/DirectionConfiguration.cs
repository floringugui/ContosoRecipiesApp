using ContosoRecipiesApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoRecipiesApi.Configuration
{
    public class DirectionConfiguration : IEntityTypeConfiguration<Direction>
    {
        public void Configure(EntityTypeBuilder<Direction> builder)
        {
            builder.ToTable("Directions");

            builder.Property(s => s.Description)
                .IsRequired(false);

            builder.HasData(
                new Direction
                {
                    Id = 1,
                    Step = "Direction1",
                    Description = "Direction1 Description",
                    RecipeId = 1
                },
                new Direction
                {
                    Id = 2,
                    Step = "Direction2",
                    Description = "Direction2 Description",
                    RecipeId = 1
                },
                new Direction
                {
                    Id = 3,
                    Step = "Direction3",
                    Description = "Direction3 Description",
                    RecipeId = 1
                },
                new Direction
                {
                    Id = 4,
                    Step = "Direction4",
                    Description = "Direction4 Description",
                    RecipeId = 2
                }
            );
        }
    }
}