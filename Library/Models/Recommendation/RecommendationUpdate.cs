namespace Library.Models.Recommendation
{
    public class RecommendationUpdate
    {
        public Guid Uid { get; set; }
        public DateTime LikedDecisionDate { get; set; } = DateTime.MinValue;
        public bool IsLiked { get; set; } = false;
    }
}