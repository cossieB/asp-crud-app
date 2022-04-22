using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IGDB.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Developer? Developer { get; set; }
        public int DeveloperId { get; set; }
        public Publisher? Publisher { get; set; }
        public int PublisherId { get; set; }
        [Required]
        [DisplayName("Cover Image")]
        public string CoverImg { get; set; }

    }
}
