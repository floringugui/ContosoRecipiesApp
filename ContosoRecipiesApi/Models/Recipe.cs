using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace ContosoRecipiesApi.Models
{
    public record Recipe
    {
        //[PrimaryKey("Id")]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Direction> Directions { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public DateTime Updated { get; set; }
    }

    public record Direction
    {
        //[PrimaryKey]
        public int Id { get; set; }
        [Required]
        public string Step { get; set; }
        public string Description { get; set; }
    }

    public record Ingredient
    {
        //[PrimaryKey]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}