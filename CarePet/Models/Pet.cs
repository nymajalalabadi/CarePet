namespace CarePet.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // Dog, Cat, Bird, etc.
        public string Breed { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsAvailable { get; set; } = true;
    }
} 