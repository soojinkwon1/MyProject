using System.ComponentModel.DataAnnotations;

namespace MyWebSite.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public string? Duration { get; set; }
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateAt { get; set; }
    }
}