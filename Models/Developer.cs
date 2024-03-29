﻿using System.ComponentModel.DataAnnotations;

namespace IGDB.Models
{
    public class Developer
    {
        [Key]
        public int DeveloperId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Logo { get; set; }
        public string? Summary { get; set; }
        public string? Location { get; set; }
        public string? Country { get; set; }
        public List<Game>? Games { get; set; }
    }
}
