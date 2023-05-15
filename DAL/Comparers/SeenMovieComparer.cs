using DAL.Models;

namespace DAL.Comparers
{
    internal class SeenMovieComparer : IEqualityComparer<SeenMovie>
    {
        public bool Equals(SeenMovie x, SeenMovie y)
        {
            return x.MovieGUID == y.MovieGUID && x.UserGUID == y.UserGUID;
        }

        public int GetHashCode(SeenMovie obj)
        {
            return base.GetHashCode();
        }
    }
}