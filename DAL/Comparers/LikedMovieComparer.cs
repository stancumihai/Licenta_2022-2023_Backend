using DAL.Models;

namespace DAL.Comparers
{
    internal class LikedMovieComparer : IEqualityComparer<LikedMovie>
    {
        public bool Equals(LikedMovie x, LikedMovie y)
        {
            return x.MovieGUID == y.MovieGUID && x.UserGUID == y.UserGUID;
        }

        public int GetHashCode(LikedMovie obj)
        {
            return base.GetHashCode();
        }
    }
}