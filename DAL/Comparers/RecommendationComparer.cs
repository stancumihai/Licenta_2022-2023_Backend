using DAL.Models;
using System.Diagnostics.CodeAnalysis;

namespace DAL.Comparers
{
    public class RecommendationComparer : IEqualityComparer<Recommendation>
    {
        public bool Equals(Recommendation? x, Recommendation? y)
        {
            return x.Movie.Title == y.Movie.Title && x.UserGUID == y.UserGUID;
        }

        public int GetHashCode([DisallowNull] Recommendation obj)
        {
            return base.GetHashCode();
        }
    }
}