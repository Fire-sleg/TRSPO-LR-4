namespace RecipeAPI.Models.Dto
{
    public class RecipeDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public List<Guid>? ProductIds { get; set; } = new List<Guid>();
    }
}
