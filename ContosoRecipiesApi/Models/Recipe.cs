using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace ContosoRecipiesApi.Models
{
    public record Recipe
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Updated { get; set; }

        //public IEnumerable<Direction> Directions { get; set; }
        //public IEnumerable<Ingredient> Ingredients { get; set; }
    }
}