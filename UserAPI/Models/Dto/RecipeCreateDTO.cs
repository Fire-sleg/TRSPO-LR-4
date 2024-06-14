using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models.Dto
{
    public class RecipeCreateDTO
    {
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
    }
}
