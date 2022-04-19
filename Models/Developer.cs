using System.ComponentModel.DataAnnotations;

namespace IGDB.Models
{
    public class Developer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Logo { get; set; }
    }
}
