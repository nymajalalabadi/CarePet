using System.ComponentModel.DataAnnotations;

namespace CarePet.Models
{
    public class GalleryPhoto
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public string Category { get; set; } = string.Empty;
        
        public DateTime DateTaken { get; set; } = DateTime.Now;
        
        public string Photographer { get; set; } = string.Empty;
        
        public bool IsPublic { get; set; } = true;
    }
} 