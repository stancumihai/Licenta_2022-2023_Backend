using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class MovieSubscription
    {

        [Key]
        public Guid MovieSubscriptionGUID { get; set; }
        [ForeignKey("Movie")]
        public Guid MovieGUID { get; set; }
        [ForeignKey("User")]
        public string UserGUID { get; set; }
        public Movie Movie { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime CreatedAt { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is MovieSubscription subscription &&
                   MovieGUID.Equals(subscription.MovieGUID);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(MovieSubscriptionGUID, MovieGUID, UserGUID, Movie, User, CreatedAt);
        }
    }
}