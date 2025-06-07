namespace CarePet.Models
{
    public class CareService
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Duration { get; set; } = string.Empty;
        public string IconName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; // Grooming, Training, Veterinary, etc.
        public bool IsPopular { get; set; } = false;
    }
} 