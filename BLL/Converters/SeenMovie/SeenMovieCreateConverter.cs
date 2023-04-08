using Library.Models.SeenMovie;

namespace BLL.Converters.SeenMovie
{
    public class SeenMovieCreateConverter
    {
        public static SeenMovieCreate ToBLLModel(DAL.Models.SeenMovie seenMovieDALModel)
        {
            SeenMovieCreate seenMovieCreate = new()
            {
                MovieUid = seenMovieDALModel.MovieGUID,
                UserUid = seenMovieDALModel.UserGUID
            };

            return seenMovieCreate;
        }

        public static DAL.Models.SeenMovie ToDALModel(SeenMovieCreate seenMovieBLLModel)
        {
            DAL.Models.SeenMovie movieSubscriptionEntity = new()
            {
                MovieGUID = seenMovieBLLModel.MovieUid,
                UserGUID = seenMovieBLLModel.UserUid
            };

            return movieSubscriptionEntity;
        }
    }
}