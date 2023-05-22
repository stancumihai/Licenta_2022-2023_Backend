namespace Library.Models.PredictedGenre
{
    public class PredictedGenreCreate
    {
        public string UserUid { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Genre { get; set; }
    }
}