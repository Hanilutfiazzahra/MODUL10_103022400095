namespace MODUL10_103022400095.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public int TahunRilis { get; set; }
        public string Genre { get; set; }
        public List<string> Platform { get; set; }
        public double Rating { get; set; }
        public List<string> Mode { get; set; }
        public bool IsOnline { get; set; }
        public int Harga { get; set; }

        public Game() { }
    }
}
