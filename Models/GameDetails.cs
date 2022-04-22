namespace IGDB.Models
{
    public class GameDetails
    {
        public Game Game { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Publisher> Publishers { get; set; }
    }
}
