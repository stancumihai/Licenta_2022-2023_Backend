namespace Library.Models.MovieSubscription
{
    public class MovieSubscriptionCreate
    {
        public Guid MovieUid { get; set; }
        public string UserUid { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}