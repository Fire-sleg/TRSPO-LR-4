using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeAPI.Models
{
    public class Product
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Kcal { get; set; } = 0;
        public double Mass { get; set; } = 0;
        public int NumberOfProducts { get; set; } = 0;
        public DateTime? UpdatedDate { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
