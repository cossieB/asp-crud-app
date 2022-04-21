using System.ComponentModel.DataAnnotations;

namespace IGDB.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Logo { get; set; }
        public string? Summary { get; set; }
        public string? Headquarters { get; set; }
        public string? Country { get; set; }
        public List<Game>? Games { get; set; }
    }
}
