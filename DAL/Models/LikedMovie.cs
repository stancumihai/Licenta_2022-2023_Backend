using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class LikedMovie
    {
        [Key]
        public Guid LikedMovieGUID { get; set; }
        [ForeignKey("Movie")]
        public Guid MovieGUID { get; set; }
        [ForeignKey("User")]
        public string UserGUID { get; set; }
        public Movie Movie { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime CreatedAt { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is LikedMovie movie &&
                   MovieGUID.Equals(movie.MovieGUID);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(LikedMovieGUID, MovieGUID, UserGUID, Movie, User, CreatedAt);
        }
    }
}