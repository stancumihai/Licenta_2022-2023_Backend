using Library.Models.MovieSubscription;

namespace BLL.Interfaces
{
    public interface IMovieSubscriptions
    {
        MovieSubscriptionCreate Add(MovieSubscriptionCreate movieSubscription);
        List<MovieSubscriptionRead> GetAll();
        MovieSubscriptionRead? GetByUid(Guid uid);
        MovieSubscriptionRead Delete(Guid uid);
        MovieSubscriptionRead GetByUserAndMovie(Guid movieUid, string userGUID);
    }
}