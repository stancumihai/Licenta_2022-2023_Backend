namespace Library.Models.Excel.Movie
{
    public class Movie
    {
        public Guid MovieGUID { get; set; }
        public string MovieId { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public int Runtime { get; set; }
        public List<string> Genres { get; set; }
    }
}