using System;

namespace KlarityMVP.Models
{
    public class News    
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
