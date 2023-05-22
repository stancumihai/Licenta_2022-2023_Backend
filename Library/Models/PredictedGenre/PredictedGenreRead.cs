namespace Library.Models.PredictedGenre
{
    public class PredictedGenreRead
    {
        public Guid Uid { get; set; }
        public string UserUid { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Genre { get; set; }
    }
}