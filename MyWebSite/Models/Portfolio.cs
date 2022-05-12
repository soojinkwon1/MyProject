using System.ComponentModel.DataAnnotations;

namespace MyWebSite.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        
        [Required]
        public string? Title { get; set; }
        public string? Pic { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateAt { get; set; }
        
    }
}