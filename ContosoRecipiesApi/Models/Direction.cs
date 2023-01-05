using Microsoft.Build.Framework;

namespace ContosoRecipiesApi.Models
{
    public record Direction
    {
        public int Id { get; set; }

        [Required]
        public string Step { get; set; }

        public string Description { get; set; }

        // Foreign Key
        public int RecipeId { get; set; }

        //// Navigation property
        //public Recipe Recipe { get; set; }
    }
}