using System.ComponentModel.DataAnnotations;

namespace ContosoRecipiesApi.Models
{
    public record Recipe
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Titlul este obligatoriu.")]
        public string Title { get; set; }

        [MaxLength(255, ErrorMessage = "Lungimea campului e prea mare.")]
        public string Description { get; set; }

        public DateTime Updated { get; set; }

        public IEnumerable<Direction>? Directions { get; set; }

        public IEnumerable<Ingredient>? Ingredients { get; set; }
    }
}