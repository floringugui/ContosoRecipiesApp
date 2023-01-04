using Microsoft.Build.Framework;

namespace ContosoRecipiesApi.Models
{
    public record Ingredient
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        // Foreign Key
        public int RecipeId { get; set; }

        //// Navigation property
        //public Recipe Recipe { get; set; }
    }
}