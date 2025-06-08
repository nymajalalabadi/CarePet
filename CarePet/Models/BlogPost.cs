using System.ComponentModel.DataAnnotations;

namespace CarePet.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        public string Content { get; set; } = string.Empty;
        
        public string Author { get; set; } = string.Empty;
        
        public DateTime Date { get; set; } = DateTime.Now;
        
        public string ImageUrl { get; set; } = string.Empty;
        
        public string Category { get; set; } = string.Empty;
        
        public bool IsPublished { get; set; } = true;
        
        public int Views { get; set; } = 0;
        
        public string Summary { get; set; } = string.Empty;
        
        public int ReadTime { get; set; } = 5; // Minutes to read
        
        public List<string> Tags { get; set; } = new List<string>();
        
        // Related Articles for dynamic content
        public List<BlogPost> RelatedArticles { get; set; } = new List<BlogPost>();
        
        public string Excerpt => Content.Length > 150 ? Content.Substring(0, 150) + "..." : Content;
    }
} 