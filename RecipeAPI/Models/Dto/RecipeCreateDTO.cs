using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Models.Dto
{
    public class RecipeCreateDTO
    {
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
    }
}
