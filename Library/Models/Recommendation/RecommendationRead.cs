namespace Library.Models.Recommendation
{
    public class RecommendationRead
    {
        public Guid Uid { get; set; }
        public Guid MovieUid { get; set; }
        public string? UserUid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LikedDecisionDate { get; set; } = DateTime.MinValue;
        public bool IsLiked { get; set; } = false;
    }
}