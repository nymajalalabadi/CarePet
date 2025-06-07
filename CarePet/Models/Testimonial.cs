using System.ComponentModel.DataAnnotations;

namespace CarePet.Models
{
    public class Testimonial
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Content { get; set; } = string.Empty;
        
        [Range(1, 5)]
        public int Rating { get; set; } = 5;
        
        public string ImageUrl { get; set; } = string.Empty;
        
        public DateTime Date { get; set; } = DateTime.Now;
        
        public string PetName { get; set; } = string.Empty;
        
        public string City { get; set; } = string.Empty;
        
        public bool IsApproved { get; set; } = true;
        
        public bool IsFeatured { get; set; } = false;
    }
} 