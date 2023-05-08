using DAL.Models;

namespace DAL.Comparers
{
    internal class MovieSubscriptionComparer: IEqualityComparer<MovieSubscription>
    {
        public bool Equals(MovieSubscription x, MovieSubscription y)
        {
            return x.MovieGUID == y.MovieGUID;
        }

        public int GetHashCode(MovieSubscription obj)
        {
            return base.GetHashCode();
        }
    }
}